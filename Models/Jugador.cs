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
            if (!EsMayorEdad(edad))
            {
                throw new Exception("El jugador debe ser mayor de edad");
            }
            if (!EsNumeroValido(numero))
            {
                throw new Exception("El número de la camiseta no es válido");
            }

            this.Nombre = nombre;
            this.Edad = edad;
            this.Numero = numero;
            this.Posicion = posicion;
        }


        public void Presenetar ()
        {
            Console.WriteLine($"Hola soy {this.Nombre} Tengo {this.Edad} años y mi número es el {this.Numero}");
        }

        public Boolean EsMayorEdad(int edad)
        {
            if (edad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean EsNumeroValido(int numero)
        {
            if (numero > 0 && numero < 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidarNumeroCamiseta()
        {
            if (this.Numero > 0 && this.Numero < 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
