// **********************************************************************************
// Filename					- GDI.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Runtime.InteropServices;

namespace Core.Interop
{
    public class GDI
    {
        [DllImport("gdi32")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
    }
}
