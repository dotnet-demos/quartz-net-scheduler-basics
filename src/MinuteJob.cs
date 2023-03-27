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
}