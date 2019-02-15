using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Interfaces
{
    public interface IApplicationService
    {
        void Run(IGameView view);

        void Run(IApplicationContext context);
    }
}
