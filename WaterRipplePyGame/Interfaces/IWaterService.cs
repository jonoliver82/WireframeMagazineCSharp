// **********************************************************************************
// Filename					- IWaterService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace WaterRipplePyGame.Interfaces
{
    public interface IWaterService
    {
        Bitmap RenderOutput { get; }

        void AddSplash(int x, int y);

        void Update();
    }
}
