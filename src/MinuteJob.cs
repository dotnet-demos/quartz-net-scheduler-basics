using EasyConsole;
using Quartz;
using System;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class MinuteJob : IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            Output.WriteLine($"TRigged {nameof(MinuteJob)} at {DateTime.UtcNow}");
            await Task.Delay(1);
        }
    }
    class ThirtySecondsJob : IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            Output.WriteLine($"Trigged {nameof(MinuteJob)} at {DateTime.UtcNow}");
            await Task.Delay(1);
        }
    }
}