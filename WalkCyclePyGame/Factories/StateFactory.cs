// **********************************************************************************
// Filename					- StateFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System;
using WalkCyclePyGame.Interfaces;
using WalkCyclePyGame.Models;
using WalkCyclePyGame.States;

namespace WalkCyclePyGame.Factories
{
    public class StateFactory : IStateFactory
    {
        private readonly ISpriteService _spriteService;

        public StateFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public IPlayerState Create(State state)
        {
            switch (state)
            {
                case State.Stand:
                    {
                        var images = _spriteService.LoadImages("stand1.png");
                        return new Stand(images);
                    }

                case State.WalkLeft:
                    {
                        var images = _spriteService.LoadImages("walkleft1.png", "walkleft2.png");
                        return new WalkLeft(images);
                    }

                case State.WalkRight:
                    {
                        var images = _spriteService.LoadImages("walkright1.png", "walkright2.png");
                        return new WalkRight(images);
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(state));
                    }
            }
        }
    }
}
