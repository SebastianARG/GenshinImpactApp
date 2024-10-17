using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinApp.Logica
{
    internal class Personaje
    {
        private int id;
        /// <summary>
        /// Propiedad para obtener o asignar el id. Lanza ArgumentException si el valor es <= 0.
        /// </summary>
        /// <exception cref="ArgumentException">Lanzada si el valor es <= 0.</exception>
        public int Id 
        { 
            get { return id; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("El id debe ser mayor que 0.");
                }
                else
                {
                    id = value;
                }
                    }
        }
        public string nombre {  get; set; }

        public string elemento { get; set; }

        public string arma { get; set; }

        public int estrellas;
        public int Estrellas
        {
            get { return estrellas; }
            set
            {
                if (value == 4 || value == 5)
                {
                    estrellas = value;
                }
                else
                {
                    throw new ArgumentException("Tiene que ser 4 o 5 estrellas.");
                }
            }
        }
        public string Region { get; set; }

        public Personaje() { }

        public Personaje(int id, string nombre, string elemento, string arma, int estrellas)
        {
            this.id = id ;
            this.nombre = nombre;
            this.elemento = elemento;
            this.arma = arma;
            this.estrellas = estrellas;
        }

        public override bool Equals(object? obj)
        {
            return obj is Personaje personaje &&
                   id == personaje.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }

        public override string ToString()
        {
            return string.Format("Personaje{{ id: {0}, nombre: {1}, elemento: {2}, arma: {3}, estrellas: {4}}}",
                id, nombre, elemento, arma, estrellas);
        }
    }
}
