using System;
using System.Diagnostics;

namespace BurgerMonkeys.Tools
{
    public class TimerMonitor : IDisposable
    {
        private readonly Stopwatch _stopwatch;
        private readonly string _tag;

        /// <summary>
        /// Class used to monitor the time elapsed 
        /// </summary>
        /// <param name="tag">Paramter used to identification time in console</param>
        public TimerMonitor(string tag)
        {
            _tag = tag;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            Console.WriteLine($"\"{_tag}\" time elapsed: {_stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
