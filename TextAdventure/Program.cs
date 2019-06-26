// **********************************************************************************
// Filename					- Program.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

namespace TextAdventure
{
    public static class Program
    {
        public static void Main()
        {
            var game = new Game();
            game.Initialise();
            game.Run();
        }
    }
}
