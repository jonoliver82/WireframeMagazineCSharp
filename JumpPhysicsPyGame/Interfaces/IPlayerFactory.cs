// **********************************************************************************
// Filename					- IPlayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using JumpPhysicsPyGame.Models;

namespace JumpPhysicsPyGame.Interfaces
{
    public interface IPlayerFactory
    {
        Player Create(int x, int y);
    }
}
