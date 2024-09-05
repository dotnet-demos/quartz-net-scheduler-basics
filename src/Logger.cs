using EasyConsole;
using System;
using System.Threading;
namespace ConsoleApp
{
    class Logger
    {
        internal static void WriteInfo(string message){
            Output.WriteLine($"[{DateTime.Now.ToLongTimeString()}][Thread: {Thread.CurrentThread.ManagedThreadId}] {message}");
        }
    }
}