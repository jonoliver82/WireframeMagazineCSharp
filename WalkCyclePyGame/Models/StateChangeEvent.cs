using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkCyclePyGame.Models
{
    public class StateChangeEvent
    {
        public StateChangeEvent(DateTime time, State newState)
        {
            Time = time;
            NewState = newState;
        }

        public DateTime Time { get; private set; }

        public State NewState { get; private set; }
    }
}
