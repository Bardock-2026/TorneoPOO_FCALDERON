using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoPOO_EMANOSALVAS.Models
{
    public class Partido
    {
        public Equipo Local { get; set; }
        public Equipo Visitante { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }


        //Contructor
        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar) 
        {
            this.Local = local;
            this.Visitante  = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar; 
        
        
        }



        //Acciones: programar, mostrar resumen.
        public void Programar(Equipo local, Equipo visitante, DateTime fecha, string lugar)
        {
            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar;
            Console.WriteLine("Partido programado correctamente");
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