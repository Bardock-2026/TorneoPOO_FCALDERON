using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoPOO_FCALDERON.Generales;
using TorneoPOO_FCALDERON.Models;

namespace TorneoPOO_FCALDERON.Models
{
    public class Equipo
    {
        // ATRIBUTOS
        private int id; // PK principal
        private string nombre;
        private string ciudad;
        private string entrenador;
        private int titulos;
        private string estadio;

        // PROPIEDADES
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Entrenador
        {
            get => entrenador;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre del entrenador no puede estar vacío.");
                }
                entrenador = value;
            }
        }
        public int Titulos
        {
            get => titulos;
            set
            {
                if (value < 0)
                {
                    throw new Exception("La cantidad de títulos no puede ser negativa.");
                }
                titulos = value;
            }
        }
        public string Estadio
        {
            get => estadio;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre del estadio no puede estar vacío.");
                }
                estadio = value;
            }
        }

        // Relación con Jugadores (1 Equipo → muchos Jugadores)
        public List<Jugador> Jugadores { get; set; } = new List<Jugador>();

        // CONSTRUCTORES
        public Equipo(string nombre, string ciudad, string entrenador, int titulos, string estadio)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre del equipo no puede estar vacío");
            }
            if (string.IsNullOrWhiteSpace(ciudad))
            {
                throw new Exception("La ciudad del equipo no puede estar vacía");
            }

            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.Entrenador = entrenador;
            this.Titulos = titulos;
            this.Estadio = estadio;
            this.Jugadores = new List<Jugador>();
        }

        // Constructor vacío requerido por EF
        public Equipo() { }

        // MÉTODOS
        public void AgregarJugador(Jugador objJugador)
        {
            if (objJugador == null)
            {
                Console.WriteLine("No se puede agregar un jugador nulo.");
                return;
            }
            this.Jugadores.Add(objJugador);
            Console.WriteLine($"Jugador {objJugador.Nombre} agregado correctamente!!");
        }

        public void ListarPlantilla()
        {
            Console.WriteLine($"Plantilla del equipo {this.Nombre} de la ciudad de {this.Ciudad}:");
            if (Jugadores.Count > 0)
            {
                foreach (Jugador objJugador in Jugadores)
                {
                    objJugador.Imprimir();
                    Console.WriteLine("------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Este equipo aún no tiene jugadores fichados.");
            }
        }

        public void Imprimir()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Nombre del equipo: {this.Nombre}");
            Console.WriteLine($"Ciudad del equipo: {this.Ciudad}");
            Console.WriteLine($"Entrenador: {this.Entrenador}");
            Console.WriteLine($"Títulos: {this.Titulos}");
            Console.WriteLine($"Estadio: {this.Estadio}");
            Console.WriteLine("------------------------------------");
        }
    }
}