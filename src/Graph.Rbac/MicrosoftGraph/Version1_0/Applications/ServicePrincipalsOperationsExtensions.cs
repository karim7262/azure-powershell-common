// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ServicePrincipalsOperations.
    /// </summary>
    public static partial class ServicePrincipalsOperationsExtensions
    {
            /// <summary>
            /// Get entities from servicePrincipals
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='consistencyLevel'>
            /// Indicates the requested consistency level. Documentation URL:
            /// https://developer.microsoft.com/en-us/office/blogs/microsoft-graph-advanced-queries-for-directory-objects-are-now-generally-available/
            /// </param>
            /// <param name='top'>
            /// Show only the first n items
            /// </param>
            /// <param name='skip'>
            /// Skip the first n items
            /// </param>
            /// <param name='search'>
            /// Search items by search phrases
            /// </param>
            /// <param name='filter'>
            /// Filter items by property values
            /// </param>
            /// <param name='count'>
            /// Include count of items
            /// </param>
            /// <param name='orderby'>
            /// Order items by property values
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            public static ListServicePrincipalOKResponse ListServicePrincipal(this IServicePrincipalsOperations operations, string consistencyLevel = default(string), int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.ListServicePrincipalAsync(consistencyLevel, top, skip, search, filter, count, orderby, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get entities from servicePrincipals
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='consistencyLevel'>
            /// Indicates the requested consistency level. Documentation URL:
            /// https://developer.microsoft.com/en-us/office/blogs/microsoft-graph-advanced-queries-for-directory-objects-are-now-generally-available/
            /// </param>
            /// <param name='top'>
            /// Show only the first n items
            /// </param>
            /// <param name='skip'>
            /// Skip the first n items
            /// </param>
            /// <param name='search'>
            /// Search items by search phrases
            /// </param>
            /// <param name='filter'>
            /// Filter items by property values
            /// </param>
            /// <param name='count'>
            /// Include count of items
            /// </param>
            /// <param name='orderby'>
            /// Order items by property values
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ListServicePrincipalOKResponse> ListServicePrincipalAsync(this IServicePrincipalsOperations operations, string consistencyLevel = default(string), int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListServicePrincipalWithHttpMessagesAsync(consistencyLevel, top, skip, search, filter, count, orderby, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Add new entity to servicePrincipals
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// New entity
            /// </param>
            public static MicrosoftGraphServicePrincipal CreateServicePrincipal(this IServicePrincipalsOperations operations, MicrosoftGraphServicePrincipal body)
            {
                return operations.CreateServicePrincipalAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Add new entity to servicePrincipals
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// New entity
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MicrosoftGraphServicePrincipal> CreateServicePrincipalAsync(this IServicePrincipalsOperations operations, MicrosoftGraphServicePrincipal body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateServicePrincipalWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete entity from servicePrincipals
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory object. The directoryObject type is
            /// the base type for many other directory entity types.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='servicePrincipalId'>
            /// key: id of servicePrincipal
            /// </param>
            /// <param name='ifMatch'>
            /// ETag
            /// </param>
            public static void DeleteServicePrincipal(this IServicePrincipalsOperations operations, string servicePrincipalId, string ifMatch = default(string))
            {
                operations.DeleteServicePrincipalAsync(servicePrincipalId, ifMatch).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete entity from servicePrincipals
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory object. The directoryObject type is
            /// the base type for many other directory entity types.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='servicePrincipalId'>
            /// key: id of servicePrincipal
            /// </param>
            /// <param name='ifMatch'>
            /// ETag
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteServicePrincipalAsync(this IServicePrincipalsOperations operations, string servicePrincipalId, string ifMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteServicePrincipalWithHttpMessagesAsync(servicePrincipalId, ifMatch, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get entity from servicePrincipals by key
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory object. The directoryObject type is
            /// the base type for many other directory entity types.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='servicePrincipalId'>
            /// key: id of servicePrincipal
            /// </param>
            /// <param name='consistencyLevel'>
            /// Indicates the requested consistency level. Documentation URL:
            /// https://developer.microsoft.com/en-us/office/blogs/microsoft-graph-advanced-queries-for-directory-objects-are-now-generally-available/
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            public static MicrosoftGraphServicePrincipal GetServicePrincipal(this IServicePrincipalsOperations operations, string servicePrincipalId, string consistencyLevel = default(string), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.GetServicePrincipalAsync(servicePrincipalId, consistencyLevel, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get entity from servicePrincipals by key
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory object. The directoryObject type is
            /// the base type for many other directory entity types.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='servicePrincipalId'>
            /// key: id of servicePrincipal
            /// </param>
            /// <param name='consistencyLevel'>
            /// Indicates the requested consistency level. Documentation URL:
            /// https://developer.microsoft.com/en-us/office/blogs/microsoft-graph-advanced-queries-for-directory-objects-are-now-generally-available/
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MicrosoftGraphServicePrincipal> GetServicePrincipalAsync(this IServicePrincipalsOperations operations, string servicePrincipalId, string consistencyLevel = default(string), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetServicePrincipalWithHttpMessagesAsync(servicePrincipalId, consistencyLevel, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update entity in servicePrincipals
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory object. The directoryObject type is
            /// the base type for many other directory entity types.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='servicePrincipalId'>
            /// key: id of servicePrincipal
            /// </param>
            /// <param name='body'>
            /// New property values
            /// </param>
            public static void UpdateServicePrincipal(this IServicePrincipalsOperations operations, string servicePrincipalId, MicrosoftGraphServicePrincipal body)
            {
                operations.UpdateServicePrincipalAsync(servicePrincipalId, body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update entity in servicePrincipals
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory object. The directoryObject type is
            /// the base type for many other directory entity types.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='servicePrincipalId'>
            /// key: id of servicePrincipal
            /// </param>
            /// <param name='body'>
            /// New property values
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task UpdateServicePrincipalAsync(this IServicePrincipalsOperations operations, string servicePrincipalId, MicrosoftGraphServicePrincipal body, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.UpdateServicePrincipalWithHttpMessagesAsync(servicePrincipalId, body, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
