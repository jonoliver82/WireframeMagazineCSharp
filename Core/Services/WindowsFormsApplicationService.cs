// **********************************************************************************
// Filename					- WindowsFormsApplicationService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

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
