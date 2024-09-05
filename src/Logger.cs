using EasyConsole;
using System;
using System.Threading;
namespace ConsoleApp
{
    class Logger
    {
        internal static void WriteError(string message)
        {
            Output.WriteLine(ConsoleColor.Red,GetFormattedMessage(message));
        }

        internal static void WriteInfo(string message)
        {
            Output.WriteLine(GetFormattedMessage(message));
        }

        private static string GetFormattedMessage(string message)
        {
            return $"[{DateTime.Now.ToLongTimeString()}][Thread: {Thread.CurrentThread.ManagedThreadId}] {message}";
        }
    }
}