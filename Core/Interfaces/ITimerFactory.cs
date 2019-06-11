using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Interfaces
{
    public interface ITimerFactory
    {
        Timer Create(Action action, int intervalMs);
    }
}
