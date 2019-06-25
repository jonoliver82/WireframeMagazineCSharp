// **********************************************************************************
// Filename					- IApplicationService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Windows.Forms;

namespace Core.Interfaces
{
    public interface IApplicationService
    {
        void Run(IGameView view);

        void Run(Form view);

        void Run(IApplicationContext context);
    }
}
