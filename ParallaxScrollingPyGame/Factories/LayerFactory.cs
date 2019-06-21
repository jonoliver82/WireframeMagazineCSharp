using ParallaxScrollingPyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParallaxScrollingPyGame.Models;
using Core.Interfaces;
using System.Drawing;

namespace ParallaxScrollingPyGame.Factories
{
    public class LayerFactory : ILayerFactory
    {
        private readonly ISpriteService _spriteService;

        public LayerFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Layer CreateBack()
        {
            return Create(_spriteService.LoadImage("image_back.png"), 1);
        }

        public Layer CreateMiddle()
        {
            return Create(_spriteService.LoadImage("image_middle.png"), 3);
        }

        public Layer CreateFront()
        {
            return Create(_spriteService.LoadImage("image_front.png"), 5);
        }

        private Layer Create(Image sprite, int scrollSpeed)
        {
            return new Layer { Img = sprite, TopLeft = new Point(0, 0), ScrollSpeed = scrollSpeed };
        }
    }
}
