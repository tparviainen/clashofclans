using System.Linq;

namespace ClashOfClans.Models
{
    public partial class LocationList
    {
        /// <summary>
        /// Provides an access to <see cref="Location"/> data for the named location.
        /// </summary>
        /// <param name="name">Location name</param>
        /// <example>
        /// <code>
        /// var coc = new ClashOfClansClient(token);
        /// var locations = (LocationList)await coc.Locations.GetLocationsAsync();
        /// var location = locations["Finland"];
        /// </code>
        /// </example>
        /// <returns>Location data</returns>
        public Location this[string name]
        {
            get => this.SingleOrDefault(l => l.Name == name);
        }
    }
}
