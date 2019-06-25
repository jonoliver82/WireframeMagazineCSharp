// **********************************************************************************
// Filename					- ILayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ParallaxScrollingPyGame.Models;

namespace ParallaxScrollingPyGame.Interfaces
{
    public interface ILayerFactory
    {
        Layer CreateBack();

        Layer CreateMiddle();

        Layer CreateFront();
    }
}
