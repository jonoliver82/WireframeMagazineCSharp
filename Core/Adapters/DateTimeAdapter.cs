// **********************************************************************************
// Filename					- DateTimeAdapter.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System;

namespace Core.Adapters
{
    public class DateTimeAdapter : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
