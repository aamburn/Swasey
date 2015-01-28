﻿using System;
using System.Linq;

namespace Swasey.Model
{
    internal class ModelPropertyDefinition : BaseDefinition, IModelPropertyDefinition
    {

        public ModelPropertyDefinition(IServiceMetadata meta) : base(meta) {}

        public QualifiedName Name { get; set; }

        public DataType Type { get; set; }

        public string Description { get; set; }

        public bool HasDescription
        {
            get { return !string.IsNullOrWhiteSpace(Description); }
        }

        public bool IsKey { get; set; }

        public bool IsRequired { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Type: {1}, IsKey: {2}, IsRequired: {3}", Name, Type, IsKey, IsRequired);
        }

    }
}