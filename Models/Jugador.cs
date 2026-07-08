using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TorneoPOO_FCALDERON.Models
{
    public class Jugador
    {
        //ATRIBUTOS O CARACTERISTICAS 

        public string Nombre { get; set; } 
        public int  Edad {  get; set; }

        public int Numero { get; set; }

        public string Posicion {  get; set; }

        //METODOS, COMPORTAMIENTO O FUNCIONES 

        //Constructor
        public Jugador(String nombre, int edad, int numero, string posicion)
        { 
            this.Nombre = nombre;
            this.Edad = edad;
            this.Numero = numero;
            this.Posicion = posicion;
        }


        public void Presenetar ()
        {
            Console.WriteLine($"Hola soy {this.Nombre} Tengo {this.Edad} años y mi número es el {this.Numero}");
        }

        public Boolean EsMayorEdad()
        {
            if (this.Edad>=18  ) 
            {
                return true;

            }
            else { return false; }
        }

        public Boolean EsNumeroValido()
        {
            if(this.Numero>=0 && this.Numero <100 ) 
            {
                return true;
            }
            else
            {  return false; }
        }



    }
}
