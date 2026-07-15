using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoPOO_EMANOSALVAS.Models
{
    public class Partido
    {
        private Equipo local;
        private Equipo visitante;
        private DateTime fecha;
        private string lugar;
        private int golesLocal;
        private int golesVisitante;
        private string arbitro;
        public Equipo Local { get => local; set => local = value; }
        public Equipo Visitante { get => visitante; set => visitante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public int GolesLocal { get => golesLocal; set => golesLocal = value; }
        public int GolesVisitante { get => golesVisitante; set => golesVisitante = value; }
        public string Arbitro { get => arbitro; set => arbitro = value; }




        //Contructor
        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar, int golesLocal, int golesVisitante, string arbitro)
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
        }
        
        public void MostrarResumen()
        {
            Console.WriteLine($"Hay un partido programado entre el local {this.Local.Nombre} y el visitante {this.Visitante.Nombre} en el lugar {this.Lugar}");
        }

        public bool ValidarEquiposDistintos()
        {
            return this.Local != this.Visitante;
        }




    }
}