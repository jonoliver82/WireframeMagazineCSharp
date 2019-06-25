// **********************************************************************************
// Filename					- IRandom.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

namespace Core.Interfaces
{
    public interface IRandom
    {
        double NextDouble();

        int Next(int maxValue);

        int Next(int minValue, int maxValue);
    }
}
