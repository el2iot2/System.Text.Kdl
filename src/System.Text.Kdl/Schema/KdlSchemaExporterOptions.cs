﻿using System.Text.Kdl.Nodes;

namespace System.Text.Kdl.Schema
{
    /// <summary>
    /// Configures the behavior of the <see cref="KdlSchemaExporter"/> APIs.
    /// </summary>
    public sealed class KdlSchemaExporterOptions
    {
        /// <summary>
        /// Gets the default configuration object used by <see cref="KdlSchemaExporter"/>.
        /// </summary>
        public static KdlSchemaExporterOptions Default { get; } = new();

        /// <summary>
        /// Determines whether non-nullable schemas should be generated for null oblivious reference types.
        /// </summary>
        /// <remarks>
        /// Defaults to <see langword="false"/>. Due to restrictions in the run-time representation of nullable reference types
        /// most occurrences are null oblivious and are treated as nullable by the serializer. A notable exception to that rule
        /// are nullability annotations of field, property and constructor parameters which are represented in the contract metadata.
        /// </remarks>
        public bool TreatNullObliviousAsNonNullable { get; init; }

        /// <summary>
        /// Defines a callback that is invoked for every schema that is generated within the type graph.
        /// </summary>
        public Func<KdlSchemaExporterContext, KdlVertex, KdlVertex>? TransformSchemaNode { get; init; }
    }
}
