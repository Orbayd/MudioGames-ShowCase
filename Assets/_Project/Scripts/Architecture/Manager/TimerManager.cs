
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MudioGames.Showcase.Managers
{
    public class TimerManager : MonoBehaviour
    {
        private List<Timer> _activeTimers = new List<Timer>();
        public Timer Register(float duration, Action timerEnd,Action timerTick)
        {
            var timer = new Timer(duration);
            timer.SetTimerEnd(timerEnd).SetTimerTick(timerTick);
            _activeTimers.Add(timer);
            return timer;
        }

        void Update()
        {
            _activeTimers.RemoveAll(x=> x.IsFinished);
            
            foreach (var timer in _activeTimers.ToArray())
            {
                timer.Update(Time.deltaTime);
            }
        }

        public class Timer
        {
            public bool IsFinished { get; private set; }
            public float Duration {get; private set;}
            private event Action _onTimerEnd;
            private event Action _onTimerTick;

            private float _speed;

            public Timer(float duration)
            {
                Duration = duration;
                IsFinished = false;
                _speed = 1;
            }
            public Timer SetTimerEnd(Action timerEnd)
            {
                 _onTimerEnd = timerEnd;
                return this;
            }
            public Timer SetTimerTick(Action timerTick)
            {
                _onTimerTick = timerTick;
                return this;
            }

            public Timer AddDuration(float value)
            {
                Duration += value;
                return this;
            }

            public Timer SetTimeSpeed(float value)
            {
                _speed = value;
                return this;
            }

            public void Update(float elapsedTime)
            {
                if(IsFinished)
                {
                    return;
                }
                _onTimerTick?.Invoke();

                Duration -= elapsedTime * _speed;
                if (Duration <= 0)
                {
                    _onTimerEnd?.Invoke();
                    IsFinished = true;
                }
            }
        }
    }
}