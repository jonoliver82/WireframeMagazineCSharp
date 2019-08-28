// **********************************************************************************
// Filename					- StateManager.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ContinuePyGame.Interfaces;
using System.Drawing;

namespace ContinuePyGame
{
    public class StateManager
    {
        private IGameState _currrent;

        public StateManager(IGameState initialState)
        {
            _currrent = initialState;
        }

        public int Frame { get; set; }

        public void Update()
        {
            // TODO
        }

        public void Draw(Graphics g)
        {
            // TODO
        }

    }
}
