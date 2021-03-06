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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// State storage for token cache
    /// </summary>
    [Serializable]
    public class AzureTokenCache : IAzureTokenCache, IAzureMsalTokenCache
    {
        /// <summary>
        /// Token Cache serialization
        /// </summary>
        public virtual byte[] CacheData {get; set;}

        /// <summary>
        /// Get the user token cache.
        /// </summary>
        public object GetUserCache()
        {
            return null;
        }

        /// <summary>
        /// Remove all token cache state
        /// </summary>
        public virtual void Clear()
        {
            CacheData = null;
        }
    }
}
