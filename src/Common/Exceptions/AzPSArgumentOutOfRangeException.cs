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

using System;
using System.IO;
using System.Management.Automation;
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.Common.Exceptions
{
    /// <summary>
    /// Representive of ArgumentOutOfRangeException in Azure PowerShell
    /// </summary>
    public class AzPSArgumentOutOfRangeException : PSArgumentOutOfRangeException, IContainsAzPSErrorData
    {
        /// <summary>
        /// The parameter name that results in this exception.
        /// </summary>
        private string ErrorParamName
        {
            get => Data.GetValue<string>(AzurePSErrorDataKeys.ParamNameKey);
            set => Data.SetValue(AzurePSErrorDataKeys.ParamNameKey, value);
        }

        /// <summary>
        /// ErrorKind that causes this exception.
        /// </summary>
        public ErrorKind ErrorKind
        {
            get => Data.GetValue<ErrorKind>(AzurePSErrorDataKeys.ErrorKindKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorKindKey, value);
        }

        /// <summary>
        /// The error message which doesn't contain PII.
        /// </summary>
        public string DesensitizedErrorMessage
        {
            get => Data.GetValue<string>(AzurePSErrorDataKeys.DesensitizedErrorMessageKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.DesensitizedErrorMessageKey, value);
        }

        /// <summary>
        /// The number of line when exception happens.
        /// </summary>
        public int? ErrorLineNumber
        {
            get => Data.GetNullableValue<int>(AzurePSErrorDataKeys.ErrorLineNumberKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorLineNumberKey, value);
        }

        /// <summary>
        /// The file name when exception happens.
        /// </summary>
        public string ErrorFileName
        {
            get => Data.GetValue<string>(AzurePSErrorDataKeys.ErrorFileNameKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorFileNameKey, value);
        }

        /// <summary>
        /// Construtor of AzPSArgumentOutOfRangeException
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The parameter name that results in this exception.</param>
        /// <param name="actualValue">The actual value of the parameter.</param>
        /// <param name="desensitizedMessage">The error message which doesn't contain PII.</param>
        /// <param name="lineNumber">The number of line when exception happens.</param>
        /// <param name="filePath">The file path when exception happens.</param>
        public AzPSArgumentOutOfRangeException(
            string message,
            string paramName,
            object actualValue = null,
            string desensitizedMessage = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : this(message, paramName, ErrorKind.UserError, null, desensitizedMessage, lineNumber, filePath)
        {
        }

        /// <summary>
        /// Construtor of AzPSArgumentOutOfRangeException
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The parameter name that results in this exception.</param>
        /// <param name="errorKind">ErrorKind that causes this exception.</param>
        /// <param name="actualValue">The actual value of the parameter.</param>
        /// <param name="desensitizedMessage">The error message which doesn't contain PII.</param>
        /// <param name="lineNumber">The number of line when exception happens.</param>
        /// <param name="filePath">The file path when exception happens.</param>
        public AzPSArgumentOutOfRangeException(
            string message,
            string paramName,
            ErrorKind errorKind,
            object actualValue = null,
            string desensitizedMessage = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : base(paramName, actualValue, message)
        {
            ErrorParamName = paramName;
            ErrorKind = errorKind;
            DesensitizedErrorMessage = desensitizedMessage;
            ErrorLineNumber = lineNumber;
            if (!string.IsNullOrEmpty(filePath))
            {
                ErrorFileName = Path.GetFileNameWithoutExtension(filePath);
            }
        }

        /// <summary>
        /// Construtor of AzPSArgumentOutOfRangeException
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. Default value is null.</param>
        /// <param name="desensitizedMessage">The error message which doesn't contain PII.</param>
        /// <param name="lineNumber">The number of line when exception happens.</param>
        /// <param name="filePath">The file path when exception happens.</param>
        public AzPSArgumentOutOfRangeException(
            string message,
            Exception innerException,
            string desensitizedMessage = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : this(message,innerException, ErrorKind.UserError, desensitizedMessage, lineNumber, filePath)
        {
        }

        /// <summary>
        /// Construtor of AzPSArgumentOutOfRangeException
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. Default value is null.</param>
        /// <param name="errorKind">ErrorKind that causes this exception.</param>
        /// <param name="desensitizedMessage">The error message which doesn't contain PII.</param>
        /// <param name="lineNumber">The number of line when exception happens.</param>
        /// <param name="filePath">The file path when exception happens.</param>
        public AzPSArgumentOutOfRangeException(
            string message,
            Exception innerException,
            ErrorKind errorKind,
            string desensitizedMessage = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : base(message, innerException)
        {
            ErrorKind = errorKind;
            DesensitizedErrorMessage = desensitizedMessage;
            ErrorLineNumber = lineNumber;
            if (!string.IsNullOrEmpty(filePath))
            {
                ErrorFileName = Path.GetFileNameWithoutExtension(filePath);
            }
        }
    }
}
