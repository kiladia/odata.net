﻿//---------------------------------------------------------------------
// <copyright file="ODataMessageInfo.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

namespace Microsoft.OData
{
    using System;
    using System.IO;
    using System.Text;
#if PORTABLELIB
    using System.Threading.Tasks;
#endif
    using Microsoft.OData.Edm;

    /// <summary>
    /// Class provides context informatation of certain <see cref="IODataRequestMessage"/>
    /// or <see cref="IODataResponseMessage"/>
    /// </summary>
    public sealed class ODataMessageInfo
    {
        /// <summary>The parsed content type as <see cref="ODataMediaType"/>.</summary>
        public ODataMediaType MediaType { get; set; }

        /// <summary>The encoding specified in the charset parameter of contentType or the default encoding from MediaType.</summary>
        public Encoding Encoding { get; set; }

        /// <summary>The <see cref="IEdmModel"/> for the payload.</summary>
        public IEdmModel Model { get; set; }

        /// <summary>
        /// Whether is dealing with response.
        /// </summary>
        public bool IsResponse { get; set; }

        /// <summary>
        /// Function to get the message stream
        /// </summary>
        public Func<Stream> GetMessageStream { get; set; }

        /// <summary>
        /// The optional URL resolver to perform custom URL resolution for URLs read from the payload.
        /// </summary>
        public IODataUrlResolver UrlResolver { get; set; }

        /// <summary>
        /// The optional dependency injection container to get related services for message writing.
        /// </summary>
        public IServiceProvider Container { get; set; }

#if PORTABLELIB
        /// <summary>
        /// Function to get the message stream task
        /// </summary>
        public Func<Task<Stream>> GetMessageStreamAsync { get; set; }
#endif

        /// <summary>
        /// Whether the message should be read or written synchronously.
        /// </summary>
        public bool IsSynchronous { get; set; }

        /// <summary>
        /// The payload kind for the message, currently used by <see cref="ODataRawInputContext"/> only.
        /// </summary>
        internal ODataPayloadKind PayloadKind { get; set; }

        /// <summary>
        /// The message stream created by GetMessageStream or GetMessageAsync.
        /// </summary>
        internal Stream MessageStream { get; set; }

        /// <summary>
        /// The text reader to read input.
        /// </summary>
        /// <remarks>The text reader overrides Encoding and MessageStream.</remarks>
        internal TextReader TextReader { get; set; }
    }
}
