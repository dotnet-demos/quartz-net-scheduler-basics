using EasyConsole;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleApp
{
    internal class MenuService : BackgroundService
    {
        private readonly ThirtySecondsJobOption thirtySecondsJobOption;

        public MinuteJobOption Option1 { get; init; }
        public MenuService(MinuteJobOption opt1 , ThirtySecondsJobOption thirtySecondsJobOption)
        {
            Option1 = opt1;
            this.thirtySecondsJobOption = thirtySecondsJobOption;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var menu = new Menu()
                .Add("Trigger every 1 min", async (token) => await Option1.Execute())
                .Add("Trigger every 30secs using CronBuilder (not working)", async (token) => await thirtySecondsJobOption.Execute())
                .AddSync("Exit", () => Environment.Exit(0));
            await menu.Display(CancellationToken.None);
            await base.StartAsync(stoppingToken);
        }
    }
}