using System;
using System.Collections.Generic;
using System.IO;
using desafioJunior01.Services;

namespace desafioJunior01.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly string path = @"mapaAlfa.txt";
        public List<string> leerMapa()
        {
            StreamReader file = new System.IO.StreamReader(path);  
            List<string> paresCV = new List<string>();
            if(File.Exists(path))
            {
                using(StreamReader mSR = File.OpenText(path))
                {
                    // string s = mSR.ReadLine();
                    string linea = "";
                    while ( (linea = mSR.ReadLine())!= null)
                    {
                        paresCV.Add(linea);
                    }
                }
            }  
            else
            {
                throw new Exception("No se encontro el archivo \"mapaAlfa.txt\" en el directorio del proyecto");
            }


            return paresCV;
        }
    }
}
