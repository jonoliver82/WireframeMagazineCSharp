// **********************************************************************************
// Filename					- Game.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Collections.Generic;
using TextAdventure.Models;

namespace TextAdventure
{
    public class Game
    {
        private Dictionary<string, Location> _locations;
        private Location _currentLocation;
        private bool _continue = true;

        public Game()
        {
            _locations = new Dictionary<string, Location>()
            {
                { "woods", new Location("The woods", "You are in the woods. There are lots of trees.") },
                { "lake", new Location("The lake", "You are by the lake. It is very watery.") },
            };
        }

        public void Initialise()
        {
            _locations["woods"].AddLink(Direction.North, "lake");
            _locations["lake"].AddLink(Direction.South, "woods");

            _currentLocation = _locations["woods"];

            _continue = true;
        }

        public void Run()
        {
            Console.WriteLine("Q to quit");

            while (_continue)
            {
                // Display description of current location
                Console.WriteLine(_currentLocation.Description);

                // Display neighbouring locations
                foreach (var item in _currentLocation.LinkedLocations)
                {
                    Console.WriteLine($"{item.Key}: {_locations[item.Value].Name}");
                }

                // Read player input
                Console.Write('>');
                var command = Console.ReadLine().ToLower();

                if (command == "q")
                {
                    _continue = false;
                    break;
                }
                else
                {
                    Direction direction;
                    if (Enum.TryParse<Direction>(command, true, out direction))
                    {
                        if (_currentLocation.LinkedLocations.ContainsKey(direction))
                        {
                            var newLocationKey = _currentLocation.LinkedLocations[direction];
                            _currentLocation = _locations[newLocationKey];
                        }
                        else
                        {
                            Console.WriteLine("You cannot go that way");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Try one of: {string.Join(",", Enum.GetNames(typeof(Direction)))}");
                    }
                }
            }
        }
    }
}
