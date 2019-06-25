// **********************************************************************************
// Filename					- IGraphicsService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace Core.Interfaces
{
    public interface IGraphicsService
    {
        bool ColorRgbEquals(Color first, Color second);

        Color GetScreenColorAtPosition(Graphics g, Point position);
    }
}
