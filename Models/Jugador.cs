using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TorneoPOO_FCALDERON.Models
{
    public class Jugador
    {
        //ATRIBUTOS O CARACTERISTICAS 

        private string nombre;
        private int  edad;
        private int numero;
        private string posicion;
        private string nacionalidad;
        private string equipo;
        private int goles;
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Posicion { get => posicion; set => posicion = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Equipo { get => equipo; set => equipo = value; }
        public int Goles { get => goles; set => goles = value; }

        //Constructor
        public Jugador(String nombre, int edad, int numero, string posicion, string nacionalidad, string equipo, int goles)
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
            this.nacionalidad = nacionalidad;
            this.equipo = equipo;
            this.goles = goles;
        }
        //METODOS, COMPORTAMIENTO O FUNCIONES 

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
