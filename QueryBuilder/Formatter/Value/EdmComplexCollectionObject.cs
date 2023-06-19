﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using QueryBuilder.Abstracts;
using Microsoft.OData.Edm;
using QueryBuilder.Formatter.Value;
using QueryBuilder;

namespace QueryBuilder.Formatter.Value
{
    /// <summary>
    /// Represents an <see cref="IEdmObject"/> that is a collection of <see cref="IEdmComplexObject"/>s.
    /// </summary>
    // TODO: Fix attribute compilation below:
    //[NonValidatingParameterBinding]
    public class EdmComplexObjectCollection : Collection<IEdmComplexObject>, IEdmObject
    {
        private IEdmCollectionTypeReference _edmType;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmComplexObjectCollection"/> class.
        /// </summary>
        /// <param name="edmType">The edm type of the collection.</param>
        public EdmComplexObjectCollection(IEdmCollectionTypeReference edmType)
        {
            Initialize(edmType);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmComplexObjectCollection"/> class.
        /// </summary>
        /// <param name="edmType">The edm type of the collection.</param>
        /// <param name="list">The list that is wrapped by the new collection.</param>
        public EdmComplexObjectCollection(IEdmCollectionTypeReference edmType, IList<IEdmComplexObject> list)
            : base(list)
        {
            Initialize(edmType);
        }

        /// <inheritdoc/>
        public IEdmTypeReference GetEdmType()
        {
            return _edmType;
        }

        private void Initialize(IEdmCollectionTypeReference edmType)
        {
            if (edmType == null)
            {
                throw Error.ArgumentNull("edmType");
            }

            if (!edmType.ElementType().IsComplex())
            {
                throw Error.Argument("edmType",
                    SRResources.UnexpectedElementType, edmType.ElementType().ToTraceString(), edmType.ToTraceString(), typeof(IEdmComplexType).Name);
            }

            _edmType = edmType;
        }
    }
}
