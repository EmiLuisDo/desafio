using System;
using System.Threading.Tasks;

namespace desafioJunior01.Services
{
    public interface ILogger
    {
        Task registrarAsync(string mensaje);
        Task registrarErrorInesperadoAsync(string mensaje, Exception e);
        Task registrarErrorAsync(string mensaje, ExpectedException me);
        Task registrarSolicitudMapeo(string input);
        Task registrarResultadoMapeo(string output);
    }
}