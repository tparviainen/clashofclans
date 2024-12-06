using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace ClashOfClans.Core.Serialization
{
    public class TrackingContractResolver : DefaultContractResolver
    {
        private readonly HashSet<string> _initialisedProperties;

        public TrackingContractResolver(out HashSet<string> initialisedProperties)
        {
            initialisedProperties = new HashSet<string>();
            _initialisedProperties = initialisedProperties;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.Writable)
            {
                var originalValueProvider = property.ValueProvider;
                property.ValueProvider = new TrackingValueProvider(_initialisedProperties, originalValueProvider, property.PropertyName);
            }

            return property;
        }

        private class TrackingValueProvider : IValueProvider
        {
            private readonly HashSet<string> _initialisedProperties;
            private readonly IValueProvider? _innerProvider;
            private readonly string? _propertyName;

            public TrackingValueProvider(HashSet<string> initialisedProperties, IValueProvider? innerProvider, string? propertyName)
            {
                _initialisedProperties = initialisedProperties;
                _innerProvider = innerProvider;
                _propertyName = propertyName;
            }

            public object? GetValue(object target)
            {
                return _innerProvider?.GetValue(target);
            }

            public void SetValue(object target, object? value)
            {
                if (value is null)
                {
                    _initialisedProperties.Add($"{target.GetHashCode()}.{target.GetType().Name}.{_propertyName}.null");
                }
                else
                {
                    _initialisedProperties.Add($"{target.GetHashCode()}.{target.GetType().Name}.{_propertyName}");
                }

                _innerProvider?.SetValue(target, value);
            }
        }
    }
}
