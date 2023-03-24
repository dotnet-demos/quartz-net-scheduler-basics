using EasyConsole;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class MinuteJobOption
    {
        /// <summary>
        /// Use https://www.javainuse.com/cron to generate and get explanation of CRON expressions
        /// </summary>
        private const string OneMinuteCronExpression = "1 * * ? * *";
        IDependency dependency;
        ILogger<MinuteJobOption> logger;
        public MinuteJobOption(IDependency dep,ILogger<MinuteJobOption> logger)
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

            var job = JobBuilder.Create<MinuteJob>()
                .WithIdentity("MinuteJob")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("CleaningTrigger", "CleanGroup")
                    .StartNow()
                    .WithCronSchedule(OneMinuteCronExpression, x => x.WithMisfireHandlingInstructionFireAndProceed())
                    .Build();
            await scheduler.ScheduleJob(job, trigger);
            
            logger.LogInformation($"Scheduled");
        }
    }
    class MinuteJob : IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            Output.WriteLine($"TRigged {nameof(MinuteJob)} at {DateTime.UtcNow}");
            await Task.Delay(1);
        }
    }
}