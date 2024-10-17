using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinApp.Logica
{
    internal static class Metodos
    {
        public static void mostrarPersonajesPorRegion(List<Personaje> personajes)
        {
            if (personajes.Count > 0)
            {
                Console.WriteLine("Personajes de la region: {0}", personajes[0].Region);
                foreach (var personaje in personajes)
                {
                    Console.WriteLine("- " + personaje.ToString());
                }
            }
        }

        internal static void mostrarPersonajes(List<Personaje> personajes)
        {
            if (personajes.Count > 0)
            {
                Console.WriteLine("Personajes:");
                foreach (var personaje in personajes)
                {
                    Console.WriteLine("- "+personaje.ToString());
                }
            }
        }
    }
}
