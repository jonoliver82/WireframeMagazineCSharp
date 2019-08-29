// **********************************************************************************
// Filename					- IGameState.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ContinuePyGame.Interfaces
{
    public interface IGameState
    {
        Dictionary<IGameState, Func<bool>> Rules { get; }

        void Draw(Graphics g);

        void Update(TimeSpan timeInState);

        void AddTransitionRule(IGameState destinationState, Func<bool> predicate);
    }
}
