﻿using Quartz;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class MinuteJob : IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            Logger.WriteInfo($"Triggered {nameof(MinuteJob)}");
            await Task.Delay(1);
        }
    }
}