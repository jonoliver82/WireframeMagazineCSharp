// **********************************************************************************
// Filename					- TailFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using ModularSpritesPyGame.Interfaces;
using ModularSpritesPyGame.Models;

namespace ModularSpritesPyGame.Factories
{
    public class TailFactory : ITailFactory
    {
        private readonly ISpriteService _spriteService;

        public TailFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public TailHook CreateTailHook()
        {
            var sprite = _spriteService.LoadImage("tail_hook.png");
            return new TailHook(sprite);
        }

        public TailPiece CreateTailPiece()
        {
            var sprite = _spriteService.LoadImage("tail_piece.png");
            return new TailPiece(sprite);
        }
    }
}
