// **********************************************************************************
// Filename					- Program.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

namespace TextAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Initialise();
            game.Run();
        }
    }
}
