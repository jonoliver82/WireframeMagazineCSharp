using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Interfaces
{
    public interface IKeyboardGame
    {
        void KeyDown(KeyEventArgs e);

        void KeyUp(KeyEventArgs e);

        Dictionary<Keys, bool> KeyboardState { get; }
    }
}
