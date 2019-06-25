// **********************************************************************************
// Filename					- TimerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System;
using System.Windows.Forms;

namespace Core.Factories
{
    public class TimerFactory : ITimerFactory
    {
        public Timer Create(Action action, int intervalMs)
        {
            var timer = new Timer();
            timer.Interval = intervalMs;
            timer.Tick += (s, e) => action();

            return timer;
        }
    }
}
