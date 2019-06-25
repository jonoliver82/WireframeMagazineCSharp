// **********************************************************************************
// Filename					- ITailFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ModularSpritesPyGame.Models;

namespace ModularSpritesPyGame.Interfaces
{
    public interface ITailFactory
    {
        TailPiece CreateTailPiece();

        TailHook CreateTailHook();
    }
}
