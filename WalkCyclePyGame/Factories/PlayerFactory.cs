// **********************************************************************************
// Filename					- PlayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using WalkCyclePyGame.Interfaces;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly ISpriteService _spriteService;

        public PlayerFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Player Create(Point startPosition)
        {
            var stateImages = new Dictionary<State, Image[]>()
            {
                { State.Stand, _spriteService.LoadImages("stand1.png") },
                { State.WalkLeft, _spriteService.LoadImages("walkleft1.png", "walkleft2.png") },
                { State.WalkRight, _spriteService.LoadImages("walkright1.png", "walkright2.png") },
            };

            return new Player(startPosition, stateImages);
        }
    }
}
