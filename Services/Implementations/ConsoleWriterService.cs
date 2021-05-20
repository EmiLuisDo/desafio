using System;

namespace desafioJunior01.Services.Implementations
{
    public class ConsoleWriterService : IWriterService
    {
        public void escribir(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void notificarError(string mensaje, MyException exception)
        {
            escribir(mensaje);
            escribir(exception.Message);
        }

        public void notificarErrorInesperado(string mensaje, Exception exception)
        {
            escribir(mensaje);
            escribir(exception.Message);
        }
    }
}