// **********************************************************************************
// Filename					- ISpaceshipFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ThrusterMotionPyGame.Models;

namespace ThrusterMotionPyGame.Interfaces
{
    public interface ISpaceshipFactory
    {
        Spaceship Create(int displayWidth, int displayHeight);
    }
}
