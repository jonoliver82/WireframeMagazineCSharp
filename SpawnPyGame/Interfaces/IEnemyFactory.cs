// **********************************************************************************
// Filename					- IEnemyFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using SpawnPyGame.Models;

namespace SpawnPyGame.Interfaces
{
    public interface IEnemyFactory
    {
        SmallEnemy CreateSmall(int x, int y);

        MediumEnemy CreateMedium(int x, int y);

        LargeEnemy CreateLarge(int x, int y);
    }
}
