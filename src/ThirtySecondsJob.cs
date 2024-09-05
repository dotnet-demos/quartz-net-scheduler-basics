using EasyConsole;
using Quartz;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class ThirtySecondsJob : IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            Logger.WriteInfo($"Triggered {nameof(ThirtySecondsJob)}");
            await Task.Delay(1);
        }
    }
}