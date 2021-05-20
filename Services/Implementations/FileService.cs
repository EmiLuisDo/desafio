using System;
using System.Collections.Generic;
using System.IO;
using desafioJunior01.Services;

namespace desafioJunior01.Services.Implementations
{
    public class FileService : IFileService
    {
        public List<string> leerMapa(string path)
        {
            List<string> paresCV = new List<string>();
            if(File.Exists(path))
            {
                using(StreamReader mSR = File.OpenText(path))
                {
                    string linea = "";
                    while ( (linea = mSR.ReadLine())!= null)
                    {
                        paresCV.Add(linea);
                    }
                }
            }  
            else
            {
                String msg = "No se encontro el archivo \"./mapaAlfa.txt\" - Por favor cree uno";
                ExpectedException me = new ExpectedException(msg, true);
                throw me;
            }


            return paresCV;
        }
    }
}
