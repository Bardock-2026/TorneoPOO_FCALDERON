using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoPOO_FCALDERON.Generales;

namespace TorneoPOO_EMANOSALVAS.Models
{
    public class Partido
    {
        private int id; // Identificador UNICO OJOOOOOO
        private Equipo local;
        private Equipo visitante;
        private DateTime fecha;
        private string lugar;
        private int golesLocal;
        private int golesVisitante;
        private string arbitro;
        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("El ID del partido debe ser mayor a 0.");
                    return;
                }
                id = value;
            }
        }
        public Equipo Local { get => local; set => local = value; }
        public Equipo Visitante { get => visitante; set => visitante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public int GolesLocal
        {
            get => golesLocal;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Los goles del equipo local no pueden ser negativos.");
                    return;
                }
                golesLocal = value;
            }
        }

        public int GolesVisitante
        {
            get => golesVisitante;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Los goles del equipo visitante no pueden ser negativos.");
                    return;
                }
                golesVisitante = value;
            }
        }

        public string Arbitro
        {
            get => arbitro;
            set
            {
                if (value == null || value == "")
                {
                    Console.WriteLine("El nombre del árbitro no puede estar vacío.");
                    return;
                }
                arbitro = value;
            }
        }
      

        //Contructor
        public Partido(int id, Equipo local, Equipo visitante, DateTime fecha, string lugar, int golesLocal, int golesVisitante, string arbitro)
        {
            if (local.Nombre == visitante.Nombre)
            {
                throw new Exception("El equipo local y visitante no pueden tener el mismo nombre");
            }
           
            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar;
            this.golesLocal = golesLocal;
            this.golesVisitante = golesVisitante;
            this.arbitro = arbitro;
            if (Database.Partidos.Count == 0)
            {
                this.id = 1;
            }
            else
            {
                this.id = Database.Partidos.Max(x => x.id) + 1;
            }
        }
        
        public void MostrarResumen()
        {
            Console.WriteLine($"Hay un partido programado entre el local {this.Local.Nombre} y el visitante {this.Visitante.Nombre} en el lugar {this.Lugar}");
        }

        public bool ValidarEquiposDistintos()
        {
            return this.Local != this.Visitante;
        }

        // AÑADIR IMPRIMIR PARTIDO
        public void Imprimir()
        {
            Console.WriteLine($"ID del partido: {this.Id}");
            Console.WriteLine($"Equipo Local: {this.Local.Nombre}");
            Console.WriteLine($"Equipo Visitante: {this.Visitante.Nombre}");
            Console.WriteLine($"Fecha: {this.Fecha.ToShortDateString()}");
            Console.WriteLine($"Lugar: {this.Lugar}");
            Console.WriteLine($"Árbitro: {this.Arbitro}");
            Console.WriteLine($"Resultado: {this.GolesLocal} - {this.GolesVisitante}");
            Console.WriteLine("------------------------------------");
        }
    }
}