using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace ClashOfClans.Core.Serialization
{
    public class TrackingContractResolver : DefaultContractResolver
    {
        private readonly HashSet<string> _trackedPropertyIdentifiers;

        public TrackingContractResolver(out HashSet<string> trackedPropertyIdentifiers)
        {
            trackedPropertyIdentifiers = new HashSet<string>();
            _trackedPropertyIdentifiers = trackedPropertyIdentifiers;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.Writable)
            {
                var originalValueProvider = property.ValueProvider;
                property.ValueProvider = new TrackingValueProvider(_trackedPropertyIdentifiers, originalValueProvider, property.PropertyName);
            }

            return property;
        }

        private class TrackingValueProvider : IValueProvider
        {
            private readonly HashSet<string> _trackedPropertyIdentifiers;
            private readonly IValueProvider? _innerProvider;
            private readonly string? _propertyName;

            public TrackingValueProvider(HashSet<string> trackedPropertyIdentifiers, IValueProvider? innerProvider, string? propertyName)
            {
                _trackedPropertyIdentifiers = trackedPropertyIdentifiers;
                _innerProvider = innerProvider;
                _propertyName = propertyName;
            }

            public object? GetValue(object target)
            {
                return _innerProvider?.GetValue(target);
            }

            public void SetValue(object target, object? value)
            {
                _trackedPropertyIdentifiers.Add($"{target.GetHashCode()}.{target.GetType().Name}.{_propertyName}");
                _innerProvider?.SetValue(target, value);
            }
        }
    }
}
