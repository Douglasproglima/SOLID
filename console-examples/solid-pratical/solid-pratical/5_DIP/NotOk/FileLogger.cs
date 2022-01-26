using System;

namespace solid_pratical._5_DIP.NotOk
{
    public class FileLogger
    {
        public static void Handle(string message) => Console.WriteLine(message);
    }
}
