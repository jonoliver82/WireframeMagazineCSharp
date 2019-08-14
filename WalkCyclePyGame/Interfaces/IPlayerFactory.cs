// **********************************************************************************
// Filename					- IPlayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame.Interfaces
{
    public interface IPlayerFactory
    {
        Player Create(Point startPosition);
    }
}
