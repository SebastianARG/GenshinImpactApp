using GenshinApp.DAO;
using GenshinApp.Logica;

PersonajeDAOImpl p = new PersonajeDAOImpl(new GenshinApp.Conexion.Config());
List<Personaje> personajes;
Personaje personaje;
string nombre;
string opcion;
string[] regiones = { "mondstadt", "liyue", "inazuma", "sumeru", "fountaine", "natlan" };
string region;
bool continuando = true;
while (continuando)
{
    Console.WriteLine("Elige una opción numerica:");
    Console.WriteLine("1. Mostrar todos los personajes");
    Console.WriteLine("2. Mostrar personajes por region");
    Console.WriteLine("3. Escoger build del personaje");
    Console.WriteLine("4. Salir");

    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            personajes = p.mostrarPersonajes();
            Metodos.mostrarPersonajes(personajes);
            break;
        case "2":
            Console.WriteLine("Tengo las siguientes regiones: {0}, {1}, {2}, {3}, {4}, {5}",
                regiones[0], regiones[1], regiones[2], regiones[3], regiones[4], regiones[5]);
            Console.WriteLine("Dime una region:");
            region = Console.ReadLine();
            if (regiones.Contains(region.ToLower()))
            {
                personajes = p.mostrarPersonajesPorRegion(region);
                Metodos.mostrarPersonajesPorRegion(personajes);
            }
            else
            {
                Console.WriteLine("Esa región no existe o has escrito la region mal");
            }
            break;
        case "3":
            Console.WriteLine("Dime el nombre del personaje: ");
            nombre = Console.ReadLine();
            bool existe = p.existePersonaje(nombre);
            if (existe)
            {
                personaje = p.obtenerPersonajePorNombre(nombre);
                Console.WriteLine("- {0}", personaje.ToString());
            }
            else
            {
                Console.WriteLine("No existe ese personaje o has escrito mal el nombre");
            }
            break;
        case "4":
            continuando = false;
            break;
        default:
            Console.WriteLine("Opción no válida. Intenta de nuevo.");
            break;
    }
}
