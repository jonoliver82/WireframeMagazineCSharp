// **********************************************************************************
// Filename					- IPowerUpFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using SpriteFollowingPyGame.Models;
using System.Collections.Generic;

namespace SpriteFollowingPyGame.Interfaces
{
    public interface IPowerUpFactory
    {
        List<PowerUp> CreatePowerUps(int quantity);
    }
}
