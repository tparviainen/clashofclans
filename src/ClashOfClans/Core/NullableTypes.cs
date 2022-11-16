using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClashOfClans.Core
{
    internal class NullableTypes
    {
        private readonly HashSet<string> _checkedNullProperties = new HashSet<string>();
        private readonly Dictionary<string, int> _nullProperties = new Dictionary<string, int>();

        public NullableTypes()
        {
            Init();
        }

        internal void Init()
        {
            var filename = "CheckedNullableTypes.txt";

            if (File.Exists(filename))
            {
                var content = File.ReadAllLines(filename);

                foreach (var row in content)
                {
                    // <class:property>, <date>, total <xyz>
                    var index = row.IndexOf(',');
                    if (index > 0)
                    {
                        _checkedNullProperties.Add(row.Substring(0, index));
                    }
                }
            }
        }

        /// <summary>
        /// Adds found nullable properties to storage
        /// </summary>
        /// <param name="nullProperties"></param>
        internal void Add(IEnumerable<string> nullProperties)
        {
            foreach (var nullProperty in nullProperties)
            {
                if (_nullProperties.ContainsKey(nullProperty))
                    _nullProperties[nullProperty]++;
                else
                    _nullProperties.Add(nullProperty, 1);
            }
        }

        /// <summary>
        /// Returns a sorted list of null properties (KVP) that have not been checked or null
        /// if all properties have been checked.
        /// </summary>
        /// <returns></returns>
        internal IOrderedEnumerable<KeyValuePair<string, int>>? GetUncheckedNulls()
        {
            var keys = _nullProperties.Select(kvp => kvp.Key).Except(_checkedNullProperties);
            if (!keys.Any())
                return default;

            return _nullProperties.Where(kvp => keys.Contains(kvp.Key)).OrderBy(kvp => kvp.Key);
        }
    }
}
