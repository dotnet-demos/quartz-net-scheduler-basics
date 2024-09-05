using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System.Collections.Frozen;
using System.Linq;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class ListJobsOption
    {
        async internal Task Execute()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            var jobs = await scheduler.GetJobGroupNames();
            Logger.WriteInfo("Listing Job Groups and Jobs inside those");
            jobs.ToList().ForEach(async jobGroup =>
            {
                Logger.WriteInfo($"Job Group Name: {jobGroup}. Listing the job names in this group");
                var jobKeys = await scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals("DEFAULT"));
                jobKeys.ToList().ForEach(async jk =>
                {
                    var jd = await scheduler.GetJobDetail(jk);
                    var jts= await scheduler.GetTriggersOfJob(jk);
                    Logger.WriteInfo($"Job Name: {jk.Name}, JobType: {jd.JobType}. Below are the triggers");
                    jts.ToList().ForEach(jt => Logger.WriteInfo($"Trigger Desc: {jt.Description}, Schedule builder type:{jt.GetScheduleBuilder().GetType()}, Next fire time: {jt.GetNextFireTimeUtc()}"));
                });
            });
        }
    }
}