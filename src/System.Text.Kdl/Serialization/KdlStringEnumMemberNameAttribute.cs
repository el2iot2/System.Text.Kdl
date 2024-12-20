﻿namespace System.Text.Kdl.Serialization
{
    /// <summary>
    /// Determines the string value that should be used when serializing an enum member.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class KdlStringEnumMemberNameAttribute : Attribute
    {
        /// <summary>
        /// Creates new attribute instance with a specified enum member name.
        /// </summary>
        /// <param name="name">The name to apply to the current enum member.</param>
        public KdlStringEnumMemberNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the enum member.
        /// </summary>
        public string Name { get; }
    }
}
