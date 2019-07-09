// **********************************************************************************
// Filename					- ITileFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using BombermanPyGame.Models;

namespace BombermanPyGame.Interfaces
{
    public interface ITileFactory
    {
        Tile CreateGround();

        Tile CreateWall();
    }
}
