﻿using System;
using System.Linq;

namespace Swasey.Model
{
    internal class ServiceMetadata : IServiceMetadata
    {

        public ServiceMetadata(string apiNamespace, string modelNamespace)
        {
            ApiNamespace = apiNamespace;
            ModelNamespace = modelNamespace;
        }

        internal ServiceMetadata(IServiceMetadata copyFrom)
            : this(copyFrom.ApiNamespace, copyFrom.ModelNamespace)
        {
            ApiVersion = copyFrom.ApiVersion;
        }

        public IServiceMetadata Metadata
        {
            get { return this; }
        }

        public string ApiNamespace { get; private set; }

        public string ModelNamespace { get; private set; }

        public string ApiVersion { get; set; }
    }
}
