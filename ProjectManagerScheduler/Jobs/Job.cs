using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerScheduler.Jobs
{
    public abstract class Job : IJob
    {
        public abstract string Name { get;}
        public abstract string Schedule { get; }

        public abstract void Execute(IJobExecutionContext context);
    }
}
