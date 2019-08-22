// **********************************************************************************
// Filename					- ISpaceshipFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using SpriteFollowingPyGame.Models;
using System.Drawing;

namespace SpriteFollowingPyGame.Interfaces
{
    public interface ISpaceshipFactory
    {
        Spaceship Create(Point startPosition);
    }
}
