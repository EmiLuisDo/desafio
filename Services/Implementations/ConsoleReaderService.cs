using System;
namespace desafioJunior01.Services.Implementations
{
    public class ConsoleReaderService : IReaderService
    {
        public string readInputLine()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}