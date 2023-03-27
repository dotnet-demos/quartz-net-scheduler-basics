using Cron.Core;
using Cron.Core.Enums;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class ThirtySecondsJobOption
    {
        /// <summary>
        /// Use https://www.javainuse.com/cron to generate and get explanation of CRON expressions
        /// </summary>
        private const string OneMinuteCronExpression = "1 * * ? * *";
        IDependency dependency;
        ILogger<ThirtySecondsJobOption> logger;
        public ThirtySecondsJobOption(IDependency dep, ILogger<ThirtySecondsJobOption> logger)
        {
            dependency = dep;
            this.logger = logger;
        }
        async internal Task Execute()
        {
            logger.LogTrace($"Start");
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            var job = JobBuilder.Create<ThirtySecondsJob>()
                .WithIdentity("ThirtySecondsJob")
                .Build();

            var cronBuilder = new CronBuilder(allowSeconds:true);
            cronBuilder
                .Add(CronTimeSections.Seconds,30);
            cronBuilder.Add(CronTimeSections.DayWeek,0,6);
            string cronExpression = cronBuilder.Value;

            ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("ThirtySecondsJob")
                    .StartNow()
                    .WithCronSchedule(cronExpression, x => x.WithMisfireHandlingInstructionFireAndProceed())
                    .Build();
            await scheduler.ScheduleJob(job, trigger);

            logger.LogInformation($"Scheduled");
        }
    }
}