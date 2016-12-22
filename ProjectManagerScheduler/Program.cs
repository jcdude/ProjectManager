using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Quartz;
using Quartz.Impl;
using ProjectManagerScheduler.Quartz;
using ProjectManagerScheduler.Jobs;

namespace ProjectManagerScheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
            try
            {
                // Grab the Scheduler instance from the Factory 
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                // and start it off
                scheduler.Start();

                JobSchedulerFactory.AddScheduledJob(ref scheduler,new SendEmailJob(), "0 0/2 * * * ?");

                // some sleep to show what's happening
                Thread.Sleep(TimeSpan.FromSeconds(60));

                // and last shut down the scheduler when you are ready to close your program
                scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }

            /*ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);*/
        }
    }
}
