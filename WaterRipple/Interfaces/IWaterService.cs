using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRipple.Interfaces
{
    public interface IWaterService
    {
        Bitmap RenderOutput { get; }

        void Update();

        void AddSplash(int x, int y);
    }
}
