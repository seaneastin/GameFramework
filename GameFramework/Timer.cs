using System;
using System.Diagnostics;

namespace GameFramework
{
    class Timer
    {
       private Stopwatch _stopwatch = new Stopwatch();

        private long _currenttime = 0;
        private long _previoustime = 0;

        private float _deltatime = 0.005f;

        public Timer()
        {
            _stopwatch.Start();
        }

        public void Restart()
        {
            _stopwatch.Restart();
        }


        public float Seconds
        {
            get { return _stopwatch.ElapsedMilliseconds / 1000.0f; }
        }

        public float GetDeltaTime()
        {
            _previoustime = _currenttime;
            _currenttime = _stopwatch.ElapsedMilliseconds;
            _deltatime = (_currenttime - _previoustime) / 1000.0f;
            return _deltatime;
        }

    }
}
