using Autofac;
using Core.Adapters;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using Missiles.Interfaces;
using Missiles.Views;
using System;
using System.Windows.Forms;

namespace Missiles
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup the Dependency Injection container
            var builder = new ContainerBuilder();

            builder.Register(c => new Random());
            builder.Register(c => new RenderInformation { Width = 800, Height = 400 });
            builder.RegisterType<DateTimeAdapter>().As<IDateTimeService>();
            builder.RegisterType<RandomAdapter>().As<IRandom>();
            builder.RegisterType<WindowsFormsApplicationService>().As<IApplicationService>();

            builder.RegisterType<MissileForm>().As<IGameView>();
            builder.RegisterType<MissileGame>().As<IMissileGame>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<IApplicationService>().Run(scope.Resolve<IGameView>());
            }
        }
    }
}
