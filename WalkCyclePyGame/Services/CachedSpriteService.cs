// **********************************************************************************
// Filename					- CachedSpriteService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace WalkCyclePyGame.Services
{
    public class CachedSpriteService : ISpriteService
    {
        private readonly ISpriteService _decoratedSpriteService;

        private Dictionary<string, Image> _cache;

        public CachedSpriteService(ISpriteService decoratedSpriteService)
        {
            _decoratedSpriteService = decoratedSpriteService;

            _cache = new Dictionary<string, Image>();
        }

        public Image Load(string relativeFilePath)
        {
            if (_cache.ContainsKey(relativeFilePath))
            {
                return _cache[relativeFilePath];
            }
            else
            {
                var result = _decoratedSpriteService.Load(relativeFilePath);
                _cache[relativeFilePath] = result;
                return result;
            }
        }

        public Image LoadImage(string fileName)
        {
            if (_cache.ContainsKey(fileName))
            {
                return _cache[fileName];
            }
            else
            {
                var result = _decoratedSpriteService.LoadImage(fileName);
                _cache[fileName] = result;
                return result;
            }
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
            // We do not cache the result of this, so delegate directly to the decorated instance
            return _decoratedSpriteService.Rotate(source, angle);
        }
    }
}
