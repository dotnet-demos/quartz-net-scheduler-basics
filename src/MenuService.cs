using EasyConsole;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace ConsoleApp
{
    internal class MenuService
    {
        private readonly ThirtySecondsJobOption thirtySecondsJobOption = new ThirtySecondsJobOption();
        public MinuteJobOption minuteJobOption { get; init; } = new MinuteJobOption();
       private readonly ListJobsOption listJobsOption = new ListJobsOption();
        private readonly RemoveAllJobsOption removeAllJobsOption = new RemoveAllJobsOption();
        internal async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var menu = new Menu()
                .Add("Trigger every 30secs using SimpleSchedule", async (token) => await thirtySecondsJobOption.Execute())
                .Add("Trigger every 1 min using cron expression", async (token) => await minuteJobOption.Execute())
                .Add("List Jobs", async (token) => await listJobsOption.Execute())
                .Add("Remove all Jobs", async (token) => await removeAllJobsOption.Execute())

                .AddSync("Exit", () => Environment.Exit(0));
            while (true)
            {
                await menu.Display(CancellationToken.None);
            }
        }
    }
}