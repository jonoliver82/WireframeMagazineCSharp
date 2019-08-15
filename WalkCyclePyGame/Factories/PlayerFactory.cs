// **********************************************************************************
// Filename					- PlayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Models;
using System.Drawing;
using WalkCyclePyGame.Interfaces;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IStateFactory _stateFactory;

        public PlayerFactory(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public Player Create(Point startPosition, Bounds movementBounds)
        {
            return new Player(startPosition, movementBounds)
            {
                WalkingState = _stateFactory.Create(State.Stand),
            };
        }
    }
}
