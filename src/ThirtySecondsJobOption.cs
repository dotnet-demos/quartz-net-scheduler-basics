using EasyConsole;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class ThirtySecondsJobOption
    {
        async internal Task Execute()
        {
            Output.WriteLine($"Start");
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            var job = JobBuilder.Create<ThirtySecondsJob>()
                .WithIdentity("ThirtySecondsJob")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("ThirtySecondsJob")
                    .WithDescription("This job fires every thirty seconds")
                    .StartNow()
                    .WithSimpleSchedule(scheduleBuilder => scheduleBuilder
                        .WithIntervalInSeconds(30)
                        .RepeatForever())
                    .Build();
            await scheduler.ScheduleJob(job, trigger);

            Output.WriteLine($"{nameof(ThirtySecondsJobOption)} - Scheduled job using SimpleSchedule of 30 secs and repeat forever");
        }
    }
}