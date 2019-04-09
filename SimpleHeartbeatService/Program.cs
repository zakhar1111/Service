using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleHeartbeatService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
                {
                    x.Service<HeartBeat>(s =>   //setUp service pattern
                    {
                        s.ConstructUsing(heartbeat => new HeartBeat());
                        s.WhenStarted(heartbeat => heartbeat.Start());
                        s.WhenStopped(heartbeat => heartbeat.Stop());
                    });
                    
                    //set name + description for service
                    x.RunAsLocalSystem();
                    x.SetServiceName("HeartBeatServise");
                    x.SetDisplayName("HeartBeatServise");
                    x.SetDescription("HeartBeatServiseHeartBeatServiseHeartBeatServise");
                });

            //covert enum TopshelfExitCode to int and pass it out
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;

        }
    }
}

//[TODO] crete service that clean Temp folder
//
