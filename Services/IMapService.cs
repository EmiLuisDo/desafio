
using System;
using System.Collections.Generic;

namespace desafioJunior01.Services
{
    public interface IMapService
    {
        Dictionary<char, int> getMap(List<string> mapa);
        bool esClaveAdmisible(string clave);

       int obtenerValorAdmisible(string valor);

    }

}
