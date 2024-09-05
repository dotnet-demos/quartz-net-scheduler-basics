using System.Threading.Tasks;
using DotNet.Helpers;

namespace ConsoleApp
{
    class Program
    {
        async static Task Main (string[] args) =>
            await new MenuService().ExecuteAsync(new System.Threading.CancellationTokenSource().Token);
    }
}