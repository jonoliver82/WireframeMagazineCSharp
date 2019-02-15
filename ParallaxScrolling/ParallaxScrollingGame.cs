using ParallaxScrolling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ParallaxScrolling.Models;
using Core;
using Core.Models;

namespace ParallaxScrolling
{
    public class ParallaxScrollingGame : IParallaxScrollingGame
    {
        private readonly RenderInformation _renderInformation;
        private List<Layer> _layers;

        public ParallaxScrollingGame(RenderInformation renderInformation)
        {
            _renderInformation = renderInformation;

            _layers = new List<Layer>()
            {
                new Layer { Img = Bitmap.FromFile("image_back.png"),   TopLeft = new Point(0,0), ScrollSpeed = 1 },
                new Layer { Img = Bitmap.FromFile("image_middle.png"), TopLeft = new Point(0,0), ScrollSpeed = 3 },
                new Layer { Img = Bitmap.FromFile("image_front.png"),  TopLeft = new Point(0,0), ScrollSpeed = 5 },
            };
        }

        public void Render(Graphics graphics)
        {
            UpdateLayers();
            DrawLayers(graphics);
        }

        private void UpdateLayers()
        {
            foreach (var layer in _layers)
            {
                // Move each layer to the left
                layer.TopLeft = new Point(layer.TopLeft.X - layer.ScrollSpeed, layer.TopLeft.Y);

                // If the layer has moved far enough to the the left then reset the layers position
                if ((layer.TopLeft.X + layer.Img.Width) <= _renderInformation.Width)
                {
                    layer.TopLeft = new Point(0, 0);
                }
            }
        }

        private void DrawLayers(Graphics g)
        {
            foreach (var layer in _layers)
            {
                g.DrawImage(layer.Img, layer.TopLeft);
            }
        }
    }
}
