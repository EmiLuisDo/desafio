using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using desafioJunior01.Services;

namespace desafioJunior01.Services.Implementations
{
    public class MapService : IMapService
    {
        private readonly IStringService _stringFilterService ;
        private readonly IFileService _fileService;

        public Dictionary<char, int> getMap(string path)
        {
            List<String> mapa = _fileService.leerMapa(path);
            Dictionary<char, int> map= new Dictionary<char, int>();

            string [] clave_valor;
            string claveString = "";
            string valorString = "";

            char claveaux;
            int valoraux;
            foreach (string strMap in mapa)
            {
                clave_valor = _stringFilterService.obtenerParClaveValor(strMap);
                claveString = clave_valor[0];
                valorString = clave_valor[1];

                valoraux = obtenerValorAdmisible(valorString);
                if(esClaveAdmisible(claveString) && valoraux!=-1 )
                {
                    claveaux = claveString[0];
                    try{
                        map.Add(claveaux, valoraux);
                    }
                    catch (ArgumentException){
                        Console.WriteLine($"Elemento Clave Duplicado '{claveaux}'"); 
                    }
                }
            }
            return map;
        }
        public int obtenerValorAdmisible(string valor)
        {
            int valorI = -1;

            if(!int.TryParse(valor, out valorI))
            {
                throw new Exception($"El valor {valor} no es admisible");
            }

            return valorI;
        }
        public bool esClaveAdmisible(string clave)
        {
            bool esClave = false;
            if(clave.Length==1 && (Char.IsLetter(clave[0]) || clave[0].CompareTo(' ')==0 ) )
            {
                esClave = true;
            }
            else
            {
                throw new Exception($"La clave '{clave}' no es admisible");
            }
            return esClave;
        }

        public MapService(IStringService stringFilterService, IFileService fileService)
        {
            this._stringFilterService = stringFilterService;
            this._fileService = fileService;
        }
    }

}