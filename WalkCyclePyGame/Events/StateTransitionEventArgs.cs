// **********************************************************************************
// Filename					- StateTransitionEventArgs.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame.Events
{
    public class StateTransitionEventArgs : EventArgs
    {
        public StateTransitionEventArgs(State desiredState)
        {
            DesiredState = desiredState;
        }

        public State DesiredState { get; }
    }
}
