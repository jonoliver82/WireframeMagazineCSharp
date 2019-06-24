using Autofac;
using Core;
using Core.Adapters;
using Core.Extensions;
using Core.Factories;
using Core.Interfaces;
using Core.Services;
using Core.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterRipplePyGame.Interfaces;
using WaterRipplePyGame.Options;
using WaterRipplePyGame.Services;

namespace WaterRipplePyGame
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
                builder.Register<WaterRippleOptions>(c => jsonObject.Get<WaterRippleOptions>());
            }

            builder.Register(c => new Random());
            builder.RegisterType<RandomAdapter>().As<IRandom>();
            builder.RegisterType<DateTimeAdapter>().As<IDateTimeService>();
            builder.RegisterType<GraphicsService>().As<IGraphicsService>();
            builder.RegisterType<SpriteService>().As<ISpriteService>();
            builder.RegisterType<TimerFactory>().As<ITimerFactory>();
            builder.RegisterType<WindowsFormsApplicationService>().As<IApplicationService>();

            builder.RegisterType<WaterService>().As<IWaterService>();
            builder.RegisterType<WaterRipple>().As<PyGame>();
            builder.RegisterType<DefaultPyGameForm>().As<Form>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<IApplicationService>().Run(scope.Resolve<Form>());
            }
        }
    }
}
