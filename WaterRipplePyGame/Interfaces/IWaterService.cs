using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRipplePyGame.Interfaces
{
    public interface IWaterService
    {
        Bitmap RenderOutput { get; }

        void AddSplash(int x, int y);

        void Update();
    }
}
