using Autofac;
using Core;
using Core.Adapters;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using Explosion.Interfaces;
using Explosion.Options;
using Explosion.Services;
using Explosion.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace Explosion
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

            using (StreamReader reader = File.OpenText("appsettings.json"))
            {
                var jsonObject = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                builder.Register<ExplosionOptions>(c => jsonObject.Get<ExplosionOptions>());
            }

            builder.Register(c => new Random());
            builder.Register(c => new RenderInformation { Width = 640, Height = 480 });
            builder.RegisterType<DateTimeAdapter>().As<IDateTimeService>();
            builder.RegisterType<RandomAdapter>().As<IRandom>();
            builder.RegisterType<WindowsFormsApplicationService>().As<IApplicationService>();

            builder.RegisterType<ExplosionForm>().As<IGameView>();
            builder.RegisterType<ExplosionGame>().As<IExplosionGame>();
            builder.RegisterType<ExplosionService>().As<IExplosionService>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<IApplicationService>().Run(scope.Resolve<IGameView>());
            }
        }
    }
}
