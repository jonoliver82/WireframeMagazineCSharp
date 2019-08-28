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
        void Draw(Graphics g);

        //void Update(Dictionary<Keys, bool> keyboardState);

        void AddTransitionRule(IGameState destinationState, Func<bool> predicate);
    }
}
