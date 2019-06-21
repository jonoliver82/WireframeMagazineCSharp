using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Drawing;
using ParallaxScrollingPyGame.Models;
using ParallaxScrollingPyGame.Interfaces;

namespace ParallaxScrollingPyGame
{
    public class ParallaxScrolling : PyGame
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 400;

        private List<Layer> _layers;

        public ParallaxScrolling(ITimerFactory timerFactory, ILayerFactory layerFactory) 
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _layers = new List<Layer>()
            {
                layerFactory.CreateBack(),
                layerFactory.CreateMiddle(),
                layerFactory.CreateFront(),
            };
        }

        public override void Draw(Graphics g)
        {
            foreach (var layer in _layers)
            {
                g.DrawImage(layer.Img, layer.TopLeft);
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            foreach (var layer in _layers)
            {
                // Move each layer to the left
                layer.TopLeft = new Point(layer.TopLeft.X - layer.ScrollSpeed, layer.TopLeft.Y);

                // If the layer has moved far enough to the the left then reset the layers position
                if ((layer.TopLeft.X + layer.Img.Width) <= WIDTH)
                {
                    layer.TopLeft = new Point(0, 0);
                }
            }
        }
    }
}
