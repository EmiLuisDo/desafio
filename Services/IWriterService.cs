using System;

namespace desafioJunior01.Services
{
    public interface IWriterService
    {
        void escribir(string mensaje);

        void notificarErrorInesperado(string mensaje, Exception exception);

        void notificarError(string mensaje, MyException exception);
    }
}