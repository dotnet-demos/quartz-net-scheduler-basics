using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System.Linq;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class RemoveAllJobsOption
    {
        async internal Task Execute()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            var jobs = await scheduler.GetJobGroupNames();

            jobs.ToList().ForEach(async jobGroup =>
            {
                Logger.WriteInfo($"Deleting jobs in Group {jobGroup}");
                var jobKeys = await scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(jobGroup));
                jobKeys.ToList().ForEach(async jk =>
                {
                    var result = await scheduler.DeleteJob(jk);
                    if (result)
                    {
                        Logger.WriteInfo($"Deleted the job {jk.Name} in the group {jk.Group}");
                    }
                    else
                    {
                        Logger.WriteError($"Not able to delete the job {jk.Name} in the group {jk.Group}");
                    }
                });
            });
        }
    }
}
