using System;

namespace desafioJunior01.Services.Implementations
{
    public class ConsoleWriterService : IWriterService
    {
        public void escribir(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void notificarError(string mensaje, ExpectedException exception)
        {
            escribir(mensaje);
            escribir(exception.Message);
        }

        public void notificarErrorInesperado(string mensaje, Exception exception)
        {
            escribir(mensaje);
            escribir(exception.Message);
        }

        public void bienvenida()
        {
            escribir(">BIENVENIDO A LA APP");
            escribir(">INGRESE CADENAS DE CARACTERES (ENTER PARA TERMINAR)");
        }
        public void inicializacion()
        {
            escribir("----------------------------------------------------------------------------------------------------");
            escribir("PREPARANDO TODO...");
        }

        public void finInicializacion()
        {
            escribir("\t       ...TERMINADO");
            escribir(">(EL ALFABETO ADMISIBLE Y SUS SECUENCIAS NUMEROCAS CORRESPONDIENTES ESTAN DETERMINADOS POR EL ARCHIVO mapaAlfa.txt QUE SE ENCUENTRA EN EL DIRECTORIO DEL PROYECTO)");
            escribir("----------------------------------------------------------------------------------------------------");
        }
    }
}