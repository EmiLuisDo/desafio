using System;
using System.Collections.Generic;
using desafioJunior01.Services;
using desafioJunior01.Services.Implementations;

namespace desafioJunior01
{
    class APP
    {
        private readonly ILogger _logger;
        private readonly IInputMapper _inputMaperService;
        private readonly IReaderService _readerService;

        static void Main(string[] args)
        {
            string pathMap = @"mapaAlfa.txt";

            IMapService mapGen = new MapService(new StringService(), new FileService());
            Dictionary<char, int> map = mapGen.getMap(pathMap);

            InputMapperService maperService = new InputMapperService(map);
            IReaderService readerService = new ConsoleReaderService();
            ILogger logger = new Logger();
            APP app = new APP(logger, maperService, readerService);
            
            app.ejecutar();
        }

        public void ejecutar()
        {
            String input;
            String output;
        
            while(true)
                {
                    try
                    {
                        input = _readerService.readInputLine();
                        _logger.registrarSolicitudMapeo(input);
                        output = _inputMaperService.mapThis(input);
                        _logger.registrarResultadoMapeo(output);
                        Console.WriteLine(output);
                    }
                    catch(MyException me)
                    {
                        Console.WriteLine("Ocurrio un error - Dirijase a './log' para obtener mas detalles");
                        Console.WriteLine(me.Message);

                        _logger.registrarErrorAsync("Ocurrio un error", me);
                        break;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Ocurrio un error inesperado - Dirijase a './log' para obtener mas detalles");
                        Console.WriteLine(e.Message);

                        _logger.registrarErrorAsync("Ocurrio un error inesperado", e);
                        break;

                    }
                }


        }

        public APP(ILogger logger, IInputMapper inputMapperService, IReaderService readerService)
        {
            this._readerService = readerService;
            this._logger = logger;
            this._inputMaperService = inputMapperService;
        }
    }
}
