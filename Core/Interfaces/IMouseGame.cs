using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMouseGame
    {
        void MouseDown(int x, int y);

        void MouseMove(int x, int y);

        void MouseUp(int x, int y);
    }
}
