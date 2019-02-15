using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Newtonsoft.Json.Linq;
using System.IO;
using Core;
using Core.Adapters;
using Core.Interfaces;
using Core.Services;
using ModularSprites.Views;
using ModularSprites.Interfaces;
using ModularSprites.Options;
using Newtonsoft.Json;
using Core.Extensions;
using Core.Models;

namespace ModularSprites
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
                builder.Register<SpriteOptions>(c => jsonObject.Get<SpriteOptions>());
            }

            builder.Register(c => new Random());
            builder.Register(c => new RenderInformation { Width = 800, Height = 800 });
            builder.RegisterType<DateTimeAdapter>().As<IDateTimeService>();
            builder.RegisterType<RandomAdapter>().As<IRandom>();
            builder.RegisterType<WindowsFormsApplicationService>().As<IApplicationService>();

            builder.RegisterType<ModularSpritesForm>().As<IGameView>();
            builder.RegisterType<ModularSpritesGame>().As<IModularSpritesGame>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<IApplicationService>().Run(scope.Resolve<IGameView>());
            }
        }
    }
}
