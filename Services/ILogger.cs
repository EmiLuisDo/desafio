using System;
using System.Threading.Tasks;

namespace desafioJunior01.Services
{
    public interface ILogger
    {
        Task registrarAsync(string mensaje);
        Task registrarErrorAsync(string mensaje, Exception e);
        Task registrarSolicitudMapeo(string input);
        Task registrarResultadoMapeo(string output);
    }
}