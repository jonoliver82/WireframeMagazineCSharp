using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkCyclePyGame.Interfaces;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame.Services
{
    public class StateChangeRecordingService : IStateChangeRecorder
    {
        private readonly IDateTimeService _dateTime;
        private readonly ILogger _logger;

        private List<StateChangeEvent> _states;

        public StateChangeRecordingService(IDateTimeService dateTime, ILogger logger)
        {
            _dateTime = dateTime;
            _logger = logger;
        }

        public void RecordChange(State newState)
        {
            _states.Add(new StateChangeEvent(_dateTime.Now, newState));
        }

        public void Start()
        {
            _states = new List<StateChangeEvent>();
        }

        public void LogAndReset()
        {
            // Take a copy of the list so it is not modified when logging
            foreach (var item in _states.ToList())
            {
                _logger.Log($"{item.Time} {item.NewState}");
                _states.Clear();
            }
        }
    }
}
