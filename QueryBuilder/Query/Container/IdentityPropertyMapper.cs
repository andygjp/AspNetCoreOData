﻿namespace QueryBuilder.Query.Container
{
    internal class IdentityPropertyMapper : IPropertyMapper
    {
        public string MapProperty(string propertyName)
        {
            return propertyName;
        }
    }
}