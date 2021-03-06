// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class GeneralUtilities
    {
        private static Assembly assembly = Assembly.GetExecutingAssembly();

        private static List<string> AuthorizationHeaderNames = new List<string>() { "Authorization" };

        // this is only used to determine cutoff for streams (not xml or json).
        private const int StreamCutOffSize = 10 * 1024; //10KB

        private static bool TryFindCertificatesInStore(string thumbprint,
            System.Security.Cryptography.X509Certificates.StoreLocation location, out X509Certificate2Collection certificates)
        {
            X509Certificate2Collection found = null;
            DiskDataStore.X509StoreWrapper(StoreName.My, location, (store) =>
            {
                store.Open(OpenFlags.ReadOnly);
                found = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            });
            certificates = found;
            return certificates != null && certificates.Count > 0;
        }

        public static X509Certificate2 GetCertificateFromStore(string thumbprint)
        {
            if (string.IsNullOrWhiteSpace(thumbprint))
            {
                throw new ArgumentNullException("certificate thumbprint");
            }

            X509Certificate2Collection certificates;
            if (TryFindCertificatesInStore(thumbprint, StoreLocation.CurrentUser, out certificates) ||
                TryFindCertificatesInStore(thumbprint, StoreLocation.LocalMachine, out certificates))
            {
                return certificates[0];
            }
            else
            {
                throw new ArgumentException(string.Format(
                    "Certificate {0} was not found in the certificate store.  Please ensure the referenced " +
                    "certificate exists in the the LocalMachine\\My or CurrentUser\\My store",
                    thumbprint));
            }
        }

        /// <summary>
        /// Compares two strings with handling special case that base string can be empty.
        /// </summary>
        /// <param name="leftHandSide">The base string.</param>
        /// <param name="rightHandSide">The comparer string.</param>
        /// <returns>True if equals or leftHandSide is null/empty, false otherwise.</returns>
        public static bool TryEquals(string leftHandSide, string rightHandSide)
        {
            if (string.IsNullOrEmpty(leftHandSide) ||
                leftHandSide.Equals(rightHandSide, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }


        public static string GetConfiguration(string configurationPath)
        {
            var configuration = string.Join(string.Empty, File.ReadAllLines(configurationPath));
            return configuration;
        }

        /// <summary>
        /// Get the value for a given key in a dictionary or return a default
        /// value if the key isn't present in the dictionary.
        /// </summary>
        /// <typeparam name="K">The type of the key.</typeparam>
        /// <typeparam name="V">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">A default value</param>
        /// <returns>The corresponding value or default value.</returns>
        public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue)
        {
            Debug.Assert(dictionary != null, "dictionary cannot be null!");

            V value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Returns a non-null sequence by either passing back the original
        /// sequence or creating a new empty sequence if the original was null.
        /// </summary>
        /// <typeparam name="T">Type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>A non-null sequence.</returns>
        public static IEnumerable<T> NonNull<T>(this IEnumerable<T> sequence)
        {
            return (sequence != null) ?
                sequence :
                Enumerable.Empty<T>();
        }

        /// <summary>
        /// Perform an action on each element of a sequence.
        /// </summary>
        /// <typeparam name="T">Type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="action">The action to perform.</param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            Debug.Assert(sequence != null, "sequence cannot be null!");
            Debug.Assert(action != null, "action cannot be null!");

            foreach (T element in sequence)
            {
                action(element);
            }
        }

        /// <summary>
        /// Append an element to the end of an array.
        /// </summary>
        /// <typeparam name="T">Type of the arrays.</typeparam>
        /// <param name="left">The left array.</param>
        /// <param name="right">The right array.</param>
        /// <returns>The concatenated arrays.</returns>
        public static T[] Append<T>(T[] left, T right)
        {
            if (left == null)
            {
                return right != null ?
                    new T[] { right } :
                    new T[] { };
            }
            else if (right == null)
            {
                return left;
            }
            else
            {
                return Enumerable.Concat(left, new T[] { right }).ToArray();
            }
        }

        public static TResult MaxOrDefault<T, TResult>(this IEnumerable<T> sequence, Func<T, TResult> selector, TResult defaultValue)
        {
            return (sequence != null) ? sequence.Max(selector) : defaultValue;
        }

        /// <summary>
        /// Extends the array with one element.
        /// </summary>
        /// <typeparam name="T">The array type</typeparam>
        /// <param name="collection">The array holding elements</param>
        /// <param name="item">The item to add</param>
        /// <returns>New array with added item</returns>
        public static T[] ExtendArray<T>(IEnumerable<T> collection, T item)
        {
            if (collection == null)
            {
                collection = new T[0];
            }

            List<T> list = new List<T>(collection);
            list.Add(item);
            return list.ToArray<T>();
        }

        /// <summary>
        /// Extends the array with another array
        /// </summary>
        /// <typeparam name="T">The array type</typeparam>
        /// <param name="collection">The array holding elements</param>
        /// <param name="items">The items to add</param>
        /// <returns>New array with added items</returns>
        public static T[] ExtendArray<T>(IEnumerable<T> collection, IEnumerable<T> items)
        {
            if (collection == null)
            {
                collection = new T[0];
            }

            if (items == null)
            {
                items = new T[0];
            }

            return collection.Concat<T>(items).ToArray<T>();
        }

        /// <summary>
        /// Initializes given object if its set to null.
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="obj">The object to initialize</param>
        /// <returns>Initialized object</returns>
        public static T InitializeIfNull<T>(T obj)
            where T : new()
        {
            if (obj == null)
            {
                return new T();
            }

            return obj;
        }

        public static string EnsureTrailingSlash(string url)
        {
            UriBuilder address = new UriBuilder(url);
            if (!address.Path.EndsWith("/", StringComparison.Ordinal))
            {
                address.Path += "/";
            }
            return address.Uri.AbsoluteUri;
        }

        public static string GetHttpResponseLog(string statusCode, IDictionary<string, IEnumerable<string>> headers, string body, IList<Regex> matchers = null)
        {
            StringBuilder httpResponseLog = new StringBuilder();
            httpResponseLog.AppendLine($"============================ HTTP RESPONSE ============================{Environment.NewLine}");
            httpResponseLog.AppendLine($"Status Code:{Environment.NewLine}{statusCode}{Environment.NewLine}");
            httpResponseLog.AppendLine($"Headers:{ Environment.NewLine}{ MessageHeadersToString(headers)}");
            httpResponseLog.AppendLine($"Body:{Environment.NewLine}{TransformBody(body, matchers)}{Environment.NewLine}");
            return httpResponseLog.ToString();
        }

        public static string GetHttpResponseLog(string statusCode, HttpHeaders headers, string body, IList<Regex> matchers = null)
        {
            return GetHttpResponseLog(statusCode, ConvertHttpHeadersToWebHeaderCollection(headers), body, matchers);
        }

        public static string TransformBody(string inBody)
        {
            IList<Regex> matchers = new List<Regex>();
            Regex matcher = new Regex("(\\s*\"access_token\"\\s*:\\s*)\"[^\"]+\"");
            matchers.Add(matcher);
            return TransformBody(inBody, matchers);
        }

        public static string TransformBody(string inBody, IList<Regex> matchers)
        {
            if (matchers != null) 
            {
                foreach (Regex match in matchers)
                {
                    inBody = match.Replace(inBody, "$1\"<redacted>\"");
                }
            }
            return inBody;
        }

        public static string GetHttpRequestLog(
            string method,
            string requestUri,
            IDictionary<string, IEnumerable<string>> headers,
            string body,
            IList<Regex> matchers = null)
        {
            StringBuilder httpRequestLog = new StringBuilder();
            httpRequestLog.AppendLine(string.Format("============================ HTTP REQUEST ============================{0}", Environment.NewLine));
            httpRequestLog.AppendLine(string.Format("HTTP Method:{0}{1}{0}", Environment.NewLine, method));
            httpRequestLog.AppendLine(string.Format("Absolute Uri:{0}{1}{0}", Environment.NewLine, requestUri));
            httpRequestLog.AppendLine(string.Format("Headers:{0}{1}", Environment.NewLine, MessageHeadersToString(headers)));
            httpRequestLog.AppendLine(string.Format("Body:{0}{1}{0}", Environment.NewLine, TransformBody(body, matchers)));

            return httpRequestLog.ToString();
        }

        public static string GetHttpRequestLog(string method, string requestUri, HttpHeaders headers, string body, IList<Regex> matchers = null)
        {
            return GetHttpRequestLog(method, requestUri, ConvertHttpHeadersToWebHeaderCollection(headers), body, matchers);
        }

        public static string GetLog(HttpResponseMessage response, IList<Regex> matchers = null)
        {
            if (response == null)
            {
                return string.Empty;
            }

            string body = response.Content == null ? string.Empty
                : FormatString(response.Content.ReadAsStringAsync().Result);

            return GetHttpResponseLog(
                response.StatusCode.ToString(),
                response.Headers,
                body,
                matchers);
        }

        public static string GetLog(HttpResponseMessage response)
        {
            return GetLog(response, null);
        }

        public static string GetLog(HttpRequestMessage request, IList<Regex> matchers = null)
        {
            if (request == null)
            {
                return string.Empty;
            }

            string body = request.Content == null ? string.Empty
                : FormatString(request.Content.ReadAsStringAsync().Result);

            return GetHttpRequestLog(
                request.Method.ToString(),
                request.RequestUri.ToString(),
                (HttpHeaders)request.Headers,
                body,
                matchers);
        }

        public static string GetLog(HttpRequestMessage request)
        {
            return GetLog(request, null);
        }

        public static string FormatString(string content)
        {
            if (CloudException.IsXml(content))
            {
                return TryFormatXml(content);
            }
            else if (CloudException.IsJson(content))
            {
                return TryFormatJson(content);
            }
            else
            {
                return content.Length <= GeneralUtilities.StreamCutOffSize ? 
                    content : 
                    content.Substring(0, StreamCutOffSize) + "\r\nDATA TRUNCATED DUE TO SIZE\r\n";
            }
        }

        private static string TryFormatJson(string str)
        {
            try
            {
                object parsedJson = JsonConvert.DeserializeObject(str);
                return JsonConvert.SerializeObject(parsedJson,
                    Newtonsoft.Json.Formatting.Indented);
            }
            catch
            {
                // can't parse JSON, return the original string
                return str;
            }
        }

        private static string TryFormatXml(string content)
        {
            try
            {
                XDocument doc = XDocument.Parse(content);
                return doc.ToString();
            }
            catch (Exception)
            {
                return content;
            }
        }

        private static IDictionary<string, IEnumerable<string>> ConvertHttpHeadersToWebHeaderCollection(HttpHeaders headers)
        {
            IDictionary<string, IEnumerable<string>> webHeaders = new Dictionary<string, IEnumerable<string>>();
            foreach (KeyValuePair<string, IEnumerable<string>> pair in headers)
            {
                if (AuthorizationHeaderNames.Any(h => h.Equals(pair.Key, StringComparison.OrdinalIgnoreCase)))
                {
                    // Skip adding the authorization header
                    continue;
                }

                webHeaders.Add(pair.Key, pair.Value);
            }

            return webHeaders;
        }

        private static string MessageHeadersToString(IDictionary<string, IEnumerable<string>> headers)
        {
            string[] keys = headers.Keys.ToArray();
            StringBuilder result = new StringBuilder();

            foreach (string key in keys)
            {
                result.AppendLine(string.Format(
                    "{0,-30}: {1}",
                    key,
                    ConversionUtilities.ArrayToString(headers[key].ToArray(), ",")));
            }

            return result.ToString();
        }
		
        /// <summary>
        /// Creates https endpoint from the given endpoint.
        /// </summary>
        /// <param name="endpointUri">The endpoint uri.</param>
        /// <returns>The https endpoint uri.</returns>
        public static Uri CreateHttpsEndpoint(string endpointUri)
        {
            UriBuilder builder = new UriBuilder(endpointUri) { Scheme = "https" };
            string endpoint = builder.Uri.GetComponents(
                UriComponents.AbsoluteUri & ~UriComponents.Port,
                UriFormat.UriEscaped);

            return new Uri(endpoint);
        }


        /// <summary>
        /// Pad a string using the given separator string
        /// </summary>
        /// <param name="amount">The number of repetitions of the separator</param>
        /// <param name="separator">The separator string to use</param>
        /// <returns>A string containing the given number of repetitions of the separator string</returns>
        public static string GenerateSeparator(int amount, string separator)
        {
            StringBuilder result = new StringBuilder();
            while (amount-- != 0) result.Append(separator);
            return result.ToString();
        }

        /// <summary>
        /// Ensure the default profile directory exists
        /// </summary>
        public static void EnsureDefaultProfileDirectoryExists()
        {
            if (!AzureSession.Instance.DataStore.DirectoryExists(AzureSession.Instance.ProfileDirectory))
            {
                AzureSession.Instance.DataStore.CreateDirectory(AzureSession.Instance.ProfileDirectory);
            }
        }

        /// <summary>
        /// Checks if collection has more than one element
        /// </summary>
        /// <typeparam name="T">Type of the collection.</typeparam>
        /// <param name="collection">Collection.</param>
        /// <returns></returns>
        public static bool HasMoreThanOneElement<T>(ICollection<T> collection)
        {
            return collection != null && collection.Count > 1;
        }

        /// <summary>
        /// Checks if collection has only one element
        /// </summary>
        /// <typeparam name="T">Type of the collection.</typeparam>
        /// <param name="collection">Collection.</param>
        /// <returns></returns>
        public static bool HasSingleElement<T>(ICollection<T> collection)
        {
            return collection != null && collection.Count == 1;
        }

        /// <summary>
        /// Clear the current storage account from the context - guarantees that only one storage account will be active 
        /// at a time.
        /// </summary>
        /// <param name="clearSMContext">Whether to clear the service management context.</param>
        public static void ClearCurrentStorageAccount(bool clearSMContext = false)
        {
            if (AzureRmProfileProvider.Instance != null)
            {
                var RMProfile = AzureRmProfileProvider.Instance.Profile;
                if (RMProfile != null && RMProfile.DefaultContext != null &&
                    RMProfile.DefaultContext.Subscription != null && RMProfile.DefaultContext.Subscription.IsPropertySet(AzureSubscription.Property.StorageAccount))
                {
                    RMProfile.DefaultContext.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, null);
                }
            }
#if !NETSTANDARD
            if (clearSMContext && AzureSMProfileProvider.Instance != null)
            {
                var SMProfile = AzureSMProfileProvider.Instance.Profile;
                if (SMProfile != null && SMProfile.DefaultContext != null && SMProfile.DefaultContext.Subscription != null &&
                    SMProfile.DefaultContext.Subscription.IsPropertySet(AzureSubscription.Property.StorageAccount))
                {
                    SMProfile.DefaultContext.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, null);
                }
            }
#endif
        }

        /// <summary>
        /// Execute a process and check for a clean exit to determine if the process exists.
        /// </summary>
        /// <param name="programName">Name of the program to start.</param>
        /// <param name="args">Command line argumentes provided to the program.</param>
        /// <param name="waitTime">Time to wait for the process to close.</param>
        /// <param name="criterion">Function to evaluate the process response to determine success. The default implementation returns true if the exit code equals 0.</param>
        /// <returns></returns>
        public static bool Probe(string programName, string args = "", int waitTime = 3000, Func<ProcessExitInfo, bool> criterion = null)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = programName,
                        Arguments = args,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false
                    }
                };
                var stdout = new List<string>();
                var stderr = new List<string>();
                process.OutputDataReceived += (s, e) => stdout.Add(e.Data);
                process.ErrorDataReceived += (s, e) => stderr.Add(e.Data);
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.WaitForExit(waitTime);
                var exitInfo = new ProcessExitInfo { ExitCode = process.ExitCode, StdOut = stdout, StdErr = stderr };
                var exitCode = process.ExitCode;
                return criterion == null ? exitInfo.ExitCode == 0 : criterion(exitInfo);
            }
            catch (InvalidOperationException)
            {
                // The excutable failed to execute prior wait time expiring.
                return false;
            }
            catch (SystemException)
            {
                // The excutable doesn't exist on path. Rather than handling Win32 exception, chose to handle a less platform specific sys exception.
                return false;
            }
        }

        /// <summary>
        /// Process exit information
        /// </summary>
        public class ProcessExitInfo
        {
            /// <summary>
            /// Exit code of a process
            /// </summary>
            public int ExitCode { get; set; }

            /// <summary>
            /// List of all lines from STDOUT
            /// </summary>
            public IList<string> StdOut { get; set; }

            /// <summary>
            /// List of all lines from STDERR
            /// </summary>
            public IList<string> StdErr { get; set; }
        }
		
        public static string DownloadFile(string uri)
        {
            string contents = null;

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    contents = webClient.DownloadString(new Uri(uri));
                }
                catch
                {
                    // Ignore the exception and return empty contents
                }
            }

            return contents;
        }
    }
}