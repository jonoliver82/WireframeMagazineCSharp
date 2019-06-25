// **********************************************************************************
// Filename					- ITimerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Windows.Forms;

namespace Core.Interfaces
{
    public interface ITimerFactory
    {
        Timer Create(Action action, int intervalMs);
    }
}
