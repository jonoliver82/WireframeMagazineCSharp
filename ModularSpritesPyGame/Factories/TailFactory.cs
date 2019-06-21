using Core.Interfaces;
using ModularSpritesPyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
