using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz.Collection;
using Quartz.Impl.Matchers;
using Quartz.Spi;
using Quartz.Impl;
using ProjectManagerScheduler.Jobs;

namespace ProjectManagerScheduler.Quartz
{
    public static class JobSchedulerFactory
    {
        public static void AddScheduledJob(ref IScheduler scheduler, Job job, string schedule)
        {
            var trigger = TriggerBuilder.Create()
                            .WithIdentity("trigger_"+job.Name, "Default")
                            .WithCronSchedule(schedule)
                            .ForJob(job.Name, "Default")
                            .Build();

            var jobDetail = JobBuilder.Create<Job>()
                   .WithIdentity(job.Name, "Default")
                   .Build();

            scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
