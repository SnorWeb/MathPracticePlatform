using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MathPracticePlatform.Services
{
    public class TimerService
    {
        private readonly System.Timers.Timer _timer;
        private int _currentTime; // in seconds
        private readonly bool _isCountDown;

        public event Action<int> TimeUpdated; //actived when activated
        public event Action TimerFinished; //actived when time is up

        public TimerService(int timeInSeconds, bool isCountDown = true)
        {
            _currentTime = timeInSeconds;
            _isCountDown = isCountDown;
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_isCountDown)
            {
                _currentTime--;
                if (_currentTime <= 0)
                {
                    _timer.Stop();
                    TimerFinished?.Invoke();
                }
            }
            else
            {
                _currentTime++;
            }

            TimeUpdated?.Invoke(_currentTime); // Zorg dat TimeUpdated altijd wordt aangeroepen
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Reset(int newStartTime)
        {
            Stop();
            _currentTime = newStartTime;
            TimeUpdated?.Invoke(_currentTime);
        }
    }
}
