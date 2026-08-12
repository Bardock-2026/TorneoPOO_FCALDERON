using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoPOO_FCALDERON.Generales;

namespace TorneoPOO_FCALDERON.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Partido
    {
        // PROPIEDADES PRINCIPALES
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ID autoincremental
        public int Id { get; set; }

        private DateTime fecha;
        private string lugar;
        private string arbitro;
        private int golesLocal;
        private int golesVisitante;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public string Arbitro
        {
            get => arbitro;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("El nombre del árbitro no puede estar vacío.");
                arbitro = value;
            }
        }
        public int GolesLocal
        {
            get => golesLocal;
            set
            {
                if (value < 0)
                    throw new Exception("Los goles del equipo local no pueden ser negativos.");
                golesLocal = value;
            }
        }
        public int GolesVisitante
        {
            get => golesVisitante;
            set
            {
                if (value < 0)
                    throw new Exception("Los goles del equipo visitante no pueden ser negativos.");
                golesVisitante = value;
            }
        }

        // RELACIONES CON EQUIPO
        public int? LocalId { get; set; }
        public Equipo? Local { get; set; }

        public int? VisitanteId { get; set; }
        public Equipo? Visitante { get; set; }

        // CONSTRUCTORES
        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar, int golesLocal, int golesVisitante, string arbitro)
        {
            if (local.Nombre == visitante.Nombre)
                throw new Exception("El equipo local y visitante no pueden tener el mismo nombre");

            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar;
            this.GolesLocal = golesLocal;
            this.GolesVisitante = golesVisitante;
            this.Arbitro = arbitro;
        }

        // Constructor vacío requerido por EF
        public Partido() { }

        // MÉTODOS
        public void MostrarResumen()
        {
            Console.WriteLine($"Hay un partido programado entre el local {this.Local?.Nombre ?? "Sin equipo"} y el visitante {this.Visitante?.Nombre ?? "Sin equipo"} en el lugar {this.Lugar}");
        }

        public bool ValidarEquiposDistintos()
        {
            return this.Local != this.Visitante;
        }

        public void Imprimir()
        {
            Console.WriteLine($"ID del partido: {this.Id}");
            Console.WriteLine($"Equipo Local: {(this.Local != null ? this.Local.Nombre : "Sin equipo")}");
            Console.WriteLine($"Equipo Visitante: {(this.Visitante != null ? this.Visitante.Nombre : "Sin equipo")}");
            Console.WriteLine($"Fecha: {this.Fecha.ToShortDateString()}");
            Console.WriteLine($"Lugar: {this.Lugar}");
            Console.WriteLine($"Árbitro: {this.Arbitro}");
            Console.WriteLine($"Resultado: {this.GolesLocal} - {this.GolesVisitante}");
            Console.WriteLine("------------------------------------");
        }
    }
}