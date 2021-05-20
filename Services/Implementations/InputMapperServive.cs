using System;
using System.Collections.Generic;
using desafioJunior01.Services;

namespace desafioJunior01.Services.Implementations
{
    public class InputMapperService : IInputMapper
    {
        private readonly Dictionary<char, int> map;
        public string mapThis(string input)
        {            
            string output = "";
            string ant = "\n";
            string aux="";

            foreach (char ch in input)
            {
                try
                {
                    aux = (map[ch]).ToString();
                }
                catch (KeyNotFoundException e)
                {
                    String msg = "Clave no encontrada - Se introdujo un caracter que no se encuentra en el alfabeto - Porfavor dirijase al archivo \"./mapaAlfa.txt\" si desea agregarlo";
                    ExpectedException me = new ExpectedException(msg, e, false);
                    throw me;
                }

                if(ant[0].CompareTo(aux[0]) == 0)
                {
                    output += " ";
                }
                output += aux;
                ant = aux;
            }
            return output;
        }

        public InputMapperService(Dictionary<char, int> dict)
        {
            this.map = dict;
        }
    }
}