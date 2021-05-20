using System;

namespace desafioJunior01.Services
{
    public interface IStringService
    {
        bool esParClaveValor(string str);

        string[] obtenerParClaveValor(string cadena);
    }
}