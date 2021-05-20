
using System;
using System.Collections.Generic;

namespace desafioJunior01.Services
{
    public interface IMapService
    {
        Dictionary<char, int> getMap(string path);
        bool esClaveAdmisible(string clave);

       int obtenerValorAdmisible(string valor);

    }

}
