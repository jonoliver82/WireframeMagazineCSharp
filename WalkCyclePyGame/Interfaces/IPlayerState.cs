﻿// **********************************************************************************
// Filename					- IPlayerState.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame.Interfaces
{
    public interface IPlayerState
    {
        State State { get; }

        int FrameCount { get; }

        Image this[int index] { get; }
    }
}
