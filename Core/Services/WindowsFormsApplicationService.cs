using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Windows.Forms;

namespace Core.Services
{
    public class WindowsFormsApplicationService : IApplicationService
    {
        public void Run(IGameView view)
        {
            Application.Run(view as Form);
        }

        public void Run(Form view)
        {
            Application.Run(view);
        }

        public void Run(IApplicationContext context)
        {
            Application.Run(context as ApplicationContext);
        }
    }
}
