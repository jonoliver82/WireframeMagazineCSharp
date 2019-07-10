// **********************************************************************************
// Filename					- IPlayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using BombermanPyGame.Models;

namespace BombermanPyGame.Interfaces
{
    public interface IPlayerFactory
    {
        Player Create(int x, int y);
    }
}
