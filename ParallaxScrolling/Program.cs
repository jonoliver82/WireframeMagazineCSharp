using Autofac;
using Core;
using Core.Adapters;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using ParallaxScrolling.Interfaces;
using ParallaxScrolling.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallaxScrolling
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

            builder.RegisterType<ParallaxScrollingForm>().As<IGameView>();
            builder.RegisterType<ParallaxScrollingGame>().As<IParallaxScrollingGame>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<IApplicationService>().Run(scope.Resolve<IGameView>());
            }
        }
    }
}
