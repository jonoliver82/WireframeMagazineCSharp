﻿// **********************************************************************************
// Filename					- ISpriteService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace Core.Interfaces
{
    public interface ISpriteService
    {
        Image Load(string relativeFilePath);

        Image LoadImage(string fileName);

        Image[] LoadImages(params string[] fileNames);

        Bitmap Rotate(Image source, float angle);
    }
}
