
using System;
using System.IO;
using System.Threading.Tasks;

namespace desafioJunior01.Services.Implementations
{
    public class Logger : ILogger
    {
        private readonly string archivo = "log.txt";
        public async Task registrarAsync(string mensaje)
        {
            using (StreamWriter file = new StreamWriter(archivo, append : true))
            {
                await file.WriteLineAsync(mensaje);
            }
        }

        public async Task registrarErrorAsync(string mensaje, Exception e)
        {
            using (StreamWriter file = new StreamWriter(archivo, append : true))
            {
                DateTime momento = DateTime.Now;
                await file.WriteLineAsync("__"+momento +" "+ mensaje +" \n"+ e+"\n");
            }
        }

        public async Task registrarSolicitudMapeo(string input)
        {
            using (StreamWriter file = new StreamWriter(archivo, append : true))
            {
                DateTime momento = DateTime.Now;
                await file.WriteLineAsync("__"+momento +" "+ "Se solicito el mapeo de \"" +input +"\"" );
            }        
        }

        public async Task registrarResultadoMapeo(string output)
        {
            using (StreamWriter file = new StreamWriter(archivo, append : true))
            {
                DateTime momento = DateTime.Now;
                await file.WriteLineAsync("__"+momento +" "+ "El resultado del mapeo es \"" +output +"\"" );
            }
        }
    }
}