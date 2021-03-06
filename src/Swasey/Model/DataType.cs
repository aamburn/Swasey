﻿using System;
using System.Linq;

namespace Swasey.Model
{
    public sealed partial class DataType : IEquatable<DataType>
    {

        private readonly string _value;

        public DataType(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _value = value;
            IsEnumerable = false;
            InitializePrimitiveShortcuts(_value.Trim().ToLowerInvariant());
        }

        partial void InitializePrimitiveShortcuts(string type);

        public string DefaultValue { get; set; }

        public bool HasDefaultValue { get { return !string.IsNullOrWhiteSpace(DefaultValue); } }

        public bool HasMaximumValue { get { return !string.IsNullOrWhiteSpace(MaximumValue); } }

        public bool HasMinimumValue { get { return !string.IsNullOrWhiteSpace(MinimumValue); } }

        public bool IsDateTime { get { return Constants.DataType_DateTime.Equals(_value, StringComparison.OrdinalIgnoreCase); } }

        public bool IsEnum { get; set; }

        public bool IsEnumerable { get; set; }

        public bool IsEnumerableUnique { get; set; }

        public bool IsModelType { get; internal set; }

        public bool IsNullable { get; set; }

        public bool IsPrimitive { get; internal set; }

        public string MinimumValue { get; set; }

        public string MaximumValue { get; set; }

        public string Title20 { get; set; }

        public override string ToString()
        {
            return _value;
        }

        #region Equality

        public bool Equals(DataType other)
        {
            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return string.Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            if (ReferenceEquals(this, obj)) { return true; }
            return obj is DataType && Equals((DataType) obj);
        }

        public override int GetHashCode()
        {
            return (_value != null ? _value.GetHashCode() : 0);
        }

        public static bool operator ==(DataType left, DataType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DataType left, DataType right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region Operators

        public static implicit operator string(DataType dataType)
        {
            return dataType._value;
        }

        public static implicit operator DataType(string candidate)
        {
            return new DataType(candidate);
        }

        #endregion

    }
}
