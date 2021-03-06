// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for UsersOperations.
    /// </summary>
    public static partial class UsersOperationsExtensions
    {
            /// <summary>
            /// Get entities from users
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
            public static ListUserOKResponse ListUser(this IUsersOperations operations, string consistencyLevel = default(string), int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.ListUserAsync(consistencyLevel, top, skip, search, filter, count, orderby, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get entities from users
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
            public static async Task<ListUserOKResponse> ListUserAsync(this IUsersOperations operations, string consistencyLevel = default(string), int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListUserWithHttpMessagesAsync(consistencyLevel, top, skip, search, filter, count, orderby, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Add new entity to users
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// New entity
            /// </param>
            public static MicrosoftGraphUser CreateUser(this IUsersOperations operations, MicrosoftGraphUser body)
            {
                return operations.CreateUserAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Add new entity to users
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
            public static async Task<MicrosoftGraphUser> CreateUserAsync(this IUsersOperations operations, MicrosoftGraphUser body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateUserWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete entity from users
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory user object.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userId'>
            /// key: id of user
            /// </param>
            /// <param name='ifMatch'>
            /// ETag
            /// </param>
            public static void DeleteUser(this IUsersOperations operations, string userId, string ifMatch = default(string))
            {
                operations.DeleteUserAsync(userId, ifMatch).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete entity from users
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory user object.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userId'>
            /// key: id of user
            /// </param>
            /// <param name='ifMatch'>
            /// ETag
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteUserAsync(this IUsersOperations operations, string userId, string ifMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteUserWithHttpMessagesAsync(userId, ifMatch, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get entity from users by key
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory user object.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userId'>
            /// key: id of user
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
            public static MicrosoftGraphUser GetUser(this IUsersOperations operations, string userId, string consistencyLevel = default(string), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.GetUserAsync(userId, consistencyLevel, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get entity from users by key
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory user object.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userId'>
            /// key: id of user
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
            public static async Task<MicrosoftGraphUser> GetUserAsync(this IUsersOperations operations, string userId, string consistencyLevel = default(string), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetUserWithHttpMessagesAsync(userId, consistencyLevel, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update entity in users
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory user object.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userId'>
            /// key: id of user
            /// </param>
            /// <param name='body'>
            /// New property values
            /// </param>
            public static void UpdateUser(this IUsersOperations operations, string userId, MicrosoftGraphUser body)
            {
                operations.UpdateUserAsync(userId, body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update entity in users
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory user object.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userId'>
            /// key: id of user
            /// </param>
            /// <param name='body'>
            /// New property values
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task UpdateUserAsync(this IUsersOperations operations, string userId, MicrosoftGraphUser body, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.UpdateUserWithHttpMessagesAsync(userId, body, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get profile of current user.
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory user object.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static MicrosoftGraphUser GetMyProfile(this IUsersOperations operations)
            {
                return operations.GetMyProfileAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get profile of current user.
            /// </summary>
            /// <remarks>
            /// Represents an Azure Active Directory user object.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MicrosoftGraphUser> GetMyProfileAsync(this IUsersOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetMyProfileWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
