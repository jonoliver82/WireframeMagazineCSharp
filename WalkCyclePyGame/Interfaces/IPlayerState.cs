// **********************************************************************************
// Filename					- IPlayerState.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace WalkCyclePyGame.Interfaces
{
    public interface IPlayerState
    {
        int FrameCount { get; }

        Image this[int index] { get; }
    }
}
