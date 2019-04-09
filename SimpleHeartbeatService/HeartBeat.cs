using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleHeartbeatService
{
    public class HeartBeat
    {
        //this is the complete service

        private readonly Timer _timer;

        public HeartBeat()
        {
            //deffine event end fow often this event fired
            _timer = new Timer(1000) { AutoReset = true }; 
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //get current time && append time all the way to the end of file
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"Heartbeat.txt", lines);
        }

        //give chance through static interface to timer
        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

    }
}
