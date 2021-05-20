using System;
using System.Collections.Generic;
using desafioJunior01.Services;
using desafioJunior01.Services.Implementations;

namespace desafioJunior01
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileService mapService = new FileService();
            List<string> s = mapService.leerMapa();
            
            IMapService mapGen = new MapService(new StringService());
            Dictionary<char, int> map = mapGen.getMap(s);
            Console.WriteLine($"Verif A:{map['A']}");
            Console.WriteLine($"Verif B:{map['B']}");
            Console.WriteLine($"Verif C:{map['C']}");

            IReaderService reader = new ConsoleReaderService();
            Console.WriteLine(reader.readInputLine());
        }
    }
}
