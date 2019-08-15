using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame.Interfaces
{
    public interface IStateChangeRecorder
    {
        void Start();

        void RecordChange(State newState);

        void LogAndReset();
    }
}
