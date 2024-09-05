using EasyConsole;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class MinuteJobOption
    {
        /// <summary>
        /// Use https://www.javainuse.com/cron to generate and get explanation of CRON expressions
        /// </summary>
        private const string OneMinuteCronExpression = "1 * * ? * *";
        public MinuteJobOption()
        {
        }
        async internal Task Execute()
        {
            Output.WriteLine($"Start");
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            var job = JobBuilder.Create<MinuteJob>()
                .WithIdentity("MinuteJob")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("CleaningTrigger", "CleanGroup")
                    .StartNow()
                    .WithCronSchedule(OneMinuteCronExpression, builder => builder.WithMisfireHandlingInstructionFireAndProceed())
                    .Build();
            
            await scheduler.ScheduleJob(job, trigger);
             Output.WriteLine($"{nameof(ThirtySecondsJobOption)} - Scheduled job using cron expression {OneMinuteCronExpression}");
        }
    }
}