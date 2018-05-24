using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace serializer
{
    public class FilterContractResolver : DefaultContractResolver
    {
        private readonly string[] _filterProperties;
        public FilterContractResolver(string[] filterProperties)
        {
            _filterProperties = filterProperties;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (_filterProperties.Contains(property.PropertyName))
            {
                property.ShouldSerialize = instance => false;
            }

            return property;
        }
    }
}
