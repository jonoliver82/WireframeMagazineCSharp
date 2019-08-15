// **********************************************************************************
// Filename					- IStateFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using WalkCyclePyGame.Models;

namespace WalkCyclePyGame.Interfaces
{
    public interface IStateFactory
    {
        IPlayerState Create(State state);
    }
}
