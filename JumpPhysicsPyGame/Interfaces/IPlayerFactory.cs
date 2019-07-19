// **********************************************************************************
// Filename					- IPlayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using JumpPhysicsPyGame.Models;
using System.Drawing;

namespace JumpPhysicsPyGame.Interfaces
{
    public interface IPlayerFactory
    {
        Player Create(Point position);
    }
}
