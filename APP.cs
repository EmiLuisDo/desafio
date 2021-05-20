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
        private readonly IWriterService _writerService;

        static void Main(string[] args)
        {
            string pathMap = @"mapaAlfa.txt";
            Dictionary<char, int> map=null;
            InputMapperService maperService = null;

            //creando dependencias necesarias
            IWriterService writerService = new ConsoleWriterService();
            writerService.inicializacion();
            IReaderService readerService = new ConsoleReaderService();
            ILogger logger = new Logger();
            IMapService mapGen = new MapService(new StringService(), new FileService());
            try
            {
                map = mapGen.getMap(pathMap);
                maperService = new InputMapperService(map);
            }
            catch(MyException me)
            {

                writerService.notificarError("Ocurrio un error - Dirijase a './log' para obtener mas detalles", me);
                logger.registrarErrorAsync("Ocurrio un error ", me);
                if(me.isCritical())
                {
                    Environment.Exit(-1);
                }
            }
            catch(Exception ex)
            {
                writerService.notificarErrorInesperado("Ocurrio un error inesperado - Dirijase a './log' para obtener mas detalles", ex);
                logger.registrarErrorInesperadoAsync("Ocurrio un error inesperado", ex);
                    Environment.Exit(-1);
            }
            //fin inicializacion de dependencias
            writerService.finInicializacion();
            APP app = new APP(logger, maperService, readerService, writerService);
            
            app.ejecutar();
        }

        public void ejecutar()
        {
            String input;
            String output;
            _writerService.bienvenida();
            input = _readerService.readInputLine();
            while(input!="")
                {
                    try
                    {
                        _logger.registrarSolicitudMapeo(input);
                        output = _inputMaperService.mapThis(input);
                        _logger.registrarResultadoMapeo(output);
                        _writerService.escribir(output);
                    }
                    catch(MyException me)
                    {
                        _writerService.notificarError("Ocurrio un error - Dirijase a './log' para obtener mas detalles", me);
                        _logger.registrarErrorAsync("Ocurrio un error inesperado", me);
                        if (me.isCritical())
                        {
                            break;
                        }
                    }
                    catch(Exception e)
                    {
                        _writerService.notificarErrorInesperado("Ocurrio un error inesperado - Dirijase a './log' para obtener mas detalles", e);
                        _logger.registrarErrorInesperadoAsync("Ocurrio un error inesperado", e);
                        break;

                    }
                    input = _readerService.readInputLine();
                }


        }

        public APP(ILogger logger, IInputMapper inputMapperService, IReaderService readerService, IWriterService writerService)
        {
            this._writerService = writerService;
            this._readerService = readerService;
            this._logger = logger;
            this._inputMaperService = inputMapperService;
        }
    }
}
