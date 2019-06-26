// **********************************************************************************
// Filename					- SpriteService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System.Drawing;

namespace Core.Services
{
    public class SpriteService : ISpriteService
    {
        public Image Load(string relativeFilePath)
        {
            return Bitmap.FromFile(relativeFilePath);
        }

        public Image LoadImage(string fileName)
        {
            return Bitmap.FromFile("Images\\" + fileName);
        }
    }
}
