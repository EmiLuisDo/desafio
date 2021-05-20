using System;
using System.Linq;

namespace desafioJunior01.Services.Implementations
{
    public class StringService : IStringService
    {
        public bool esCadenaAdmisible(string cadena)
        {
            Console.WriteLine($"clave/valor: {cadena}");
            bool admisible = true;
            if( cadena.Length != 1 && Char.IsLetter(cadena[0]))
            {

            }
            return admisible;
        }

        public bool esParClaveValor(string cadena)
        {
            bool admisible = true;
            int primeraCoincidenciaSeparador = cadena.IndexOf(':');
            int ultimaCoincidenciaSeparador = cadena.LastIndexOf(':');

            if( ultimaCoincidenciaSeparador!=primeraCoincidenciaSeparador || primeraCoincidenciaSeparador<1 || ultimaCoincidenciaSeparador > cadena.Length-1)
            {
                throw new Exception($"Cadena No Admisible como par Clave Valor: {cadena}");
            }

            return admisible;
        }

        public string[] obtenerParClaveValor(string cadena)
        {
            esParClaveValor(cadena);
            int indiceSeparador = cadena.IndexOf(':');
            int ultimaCoincidenciaSeparador = cadena.LastIndexOf(':');
            string clave = cadena.Substring(0, indiceSeparador);
            string valor = cadena.Substring(indiceSeparador+1, cadena.Length-indiceSeparador-1);
            string[] par = new string [2]{clave, valor};
            return par;

        }
    }
}