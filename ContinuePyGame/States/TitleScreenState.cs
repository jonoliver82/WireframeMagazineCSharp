// **********************************************************************************
// Filename					- TitleScreenState.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace ContinuePyGame.States
{
    public class TitleScreenState : BaseGameState
    {
        public override void Draw(Graphics g)
        {
            g.DrawString("Title Screen", Font, Brush, 200, 50);
            g.DrawString("Press [space] to start", Font, Brush, 100, 80);
        }
    }
}
