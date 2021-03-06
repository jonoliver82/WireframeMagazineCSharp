﻿// **********************************************************************************
// Filename					- Program.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Autofac;
using BombermanPyGame.Factories;
using BombermanPyGame.Interfaces;
using Core;
using Core.Adapters;
using Core.Factories;
using Core.Interfaces;
using Core.Services;
using Core.Views;
using System;
using System.Windows.Forms;

namespace BombermanPyGame
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "DI Composition Root")]
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup the Dependency Injection container
            var builder = new ContainerBuilder();

            builder.Register(c => new Random());
            builder.RegisterType<RandomAdapter>().As<IRandom>();
            builder.RegisterType<DateTimeAdapter>().As<IDateTimeService>();
            builder.RegisterType<GraphicsService>().As<IGraphicsService>();
            builder.RegisterType<SpriteService>().As<ISpriteService>();
            builder.RegisterType<TimerFactory>().As<ITimerFactory>();
            builder.RegisterType<WindowsFormsApplicationService>().As<IApplicationService>();

            builder.RegisterType<PlayerFactory>().As<IPlayerFactory>();
            builder.RegisterType<TileFactory>().As<ITileFactory>();
            builder.RegisterType<Bomberman>().As<PyGame>();
            builder.RegisterType<DefaultPyGameForm>().As<Form>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<IApplicationService>().Run(scope.Resolve<Form>());
            }
        }
    }
}
