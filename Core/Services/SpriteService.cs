using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
