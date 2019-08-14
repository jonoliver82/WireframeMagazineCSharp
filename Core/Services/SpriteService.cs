// **********************************************************************************
// Filename					- SpriteService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System.Collections.Generic;
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

        public Image[] LoadImages(params string[] fileNames)
        {
            var result = new List<Image>();
            foreach (var file in fileNames)
            {
                result.Add(LoadImage(file));
            }

            return result.ToArray();
        }

        public Bitmap Rotate(Image source, float angle)
        {
            // create a new empty bitmap to hold rotated image
            Bitmap result = new Bitmap(source.Width, source.Height);

            // make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(result))
            {
                // move rotation point to center of image
                g.TranslateTransform((float)source.Width / 2, (float)source.Height / 2);

                g.RotateTransform(angle);

                // move image back
                g.TranslateTransform(-(float)source.Width / 2, -(float)source.Height / 2);

                // draw passed in image onto graphics object
                g.DrawImage(source, new Point(0, 0));
            }

            return result;
        }
    }
}
