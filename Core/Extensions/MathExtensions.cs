// **********************************************************************************
// Filename					- MathExtensions.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;

namespace Core.Extensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Not available in .NET Framework 4.5.2, but available in .NET Core 3.0 Preview 6+
        /// https://docs.microsoft.com/en-us/dotnet/api/system.math.copysign?view=netcore-3.0
        ///
        /// Source code from:
        /// https://github.com/dotnet/corefx/blob/b2097cbdcb26f7f317252334ddcce101a20b7f3d/src/Common/src/CoreLib/System/Math.cs#L165
        /// </summary>
        public static unsafe double CopySign(double x, double y)
        {
            // This method is required to work for all inputs,
            // including NaN, so we operate on the raw bits.
            var xbits = BitConverter.DoubleToInt64Bits(x);
            var ybits = BitConverter.DoubleToInt64Bits(y);

            // If the sign bits of x and y are not the same,
            // flip the sign bit of x and return the new value;
            // otherwise, just return x
            if ((xbits ^ ybits) < 0)
            {
                return BitConverter.Int64BitsToDouble(xbits ^ long.MinValue);
            }

            return x;
        }
    }
}
