// **********************************************************************************
// Filename					- RandomAdapter.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System;

namespace Core.Adapters
{
    public class RandomAdapter : IRandom
    {
        private readonly Random _random;

        public RandomAdapter(Random random)
        {
            _random = random;
        }

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            return _random.NextDouble();
        }
    }
}
