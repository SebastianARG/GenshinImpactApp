using GenshinApp.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinApp.DAO
{
    internal interface PersonajeDAO
    {
        public List<Personaje> mostrarPersonajes();
        public Personaje mostrarPersonaje(int id);

        public List<Personaje> mostrarPersonajesPorRegion(string region);
        public Boolean existePersonaje(string nombre);


    }
}
