using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Models
{
    /// <summary>
    /// Data structure to store details of each location in the game
    /// </summary>
    public class Location
    {
        private string _name;
        private string _description;
        private Dictionary<Direction, string> _linkedLocations;

        public Location(string name, string description)
        {
            _name = name;
            _description = description;
            _linkedLocations = new Dictionary<Direction, string>();
        }

        public string Name => _name;

        public string Description => _description;

        public Dictionary<Direction, string> LinkedLocations => _linkedLocations;

        /// <summary>
        /// Add link to linkedLocations dictionary
        /// </summary>
        public void AddLink(Direction direction, string locationName)
        {
            // No need to check Direction as we have strongly typed it to an enum instead of a string array
            _linkedLocations[direction] = locationName;
        }
    }
}
