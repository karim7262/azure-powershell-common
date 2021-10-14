// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Commands.Common.MSGraph
{
    using Microsoft.Azure.Commands.Common.MSGraph.Applications;
    using Microsoft.Azure.Commands.Common.MSGraph.Users;
    using Microsoft.Azure.Commands.Common.MSGraph.Groups;
    using Microsoft.Azure.Commands.Common.MSGraph.DirectoryObjects;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;

    /// <summary>
    /// The MSGraph Client.
    /// </summary>
    public partial interface IMicrosoftGraphClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// Client Api Version.
        /// </summary>
        string ApiVersion { get; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        string AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets the retry timeout in seconds for Long Running
        /// Operations. Default value is 30.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value is generated
        /// and included in each request. Default is true.
        /// </summary>
        bool? GenerateClientRequestId { get; set; }


        /// <summary>
        /// Gets the IUsersOperations.
        /// </summary>
        IUsersOperations Users { get; }

        /// <summary>
        /// Gets the IApplicationsOperations.
        /// </summary>
        IApplicationsOperations Applications { get; }

        /// <summary>
        /// Gets the IServicePrincipalsOperations.
        /// </summary>
        IServicePrincipalsOperations ServicePrincipals { get; }

        /// <summary>
        /// Gets the IGroupsOperations.
        /// </summary>
        IGroupsOperations Groups { get; }
        /// <summary>
        /// Gets the IDirectoryObjectsOperations.
        /// </summary>
        IDirectoryObjectsOperations DirectoryObjects { get; }

    }
}
