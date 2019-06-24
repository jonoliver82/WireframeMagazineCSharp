using Core;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterRipple.Interfaces;

namespace WaterRipple
{
    public class WaterRippleGame : MousePyGame, IWaterRippleGame
    {
        private readonly RenderInformation _renderInfo;
        private readonly IRandom _random;
        private readonly IWaterService _waterService;

        public WaterRippleGame(RenderInformation renderInfo, 
            IRandom random,
            IWaterService waterService)
        {
            _renderInfo = renderInfo;
            _random = random;
            _waterService = waterService;
        }

        public void Render(Graphics graphics)
        {
            _waterService.Update();

            graphics.DrawImage(_waterService.RenderOutput, 0, 0);
        }

        public void SplashRandom()
        {
            // select a random position on the screen
            var x = _random.Next(1, _renderInfo.Width - 1);
            var y = _random.Next(1, _renderInfo.Height - 1);

            //call the splash function for that position
            _waterService.AddSplash(x, y);
        }

        public override void MouseMove(int x, int y)
        {
            if(IsMouseDown)
            {
                _waterService.AddSplash(x, y);
            }
        }

        public override void MouseDown(int x, int y)
        {
            base.MouseDown(x, y);
            _waterService.AddSplash(x, y);
        }

        public override void MouseUp(int x, int y)
        {
            base.MouseUp(x, y);
            _waterService.AddSplash(x, y);
        }
    }
}
