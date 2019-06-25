// **********************************************************************************
// Filename					- ILogoFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using DoomFirePyGame.Models;

namespace DoomFirePyGame.Interfaces
{
    public interface ILogoFactory
    {
        Logo Create(int x, int y);
    }
}
