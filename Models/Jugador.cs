using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TorneoPOO_FCALDERON.Generales;

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
        private string fichado;
        private Equipo equipo_actual;
        private int id; // Principal

        //Propiedades 

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Posicion { get => posicion; set => posicion = value; }
        public string Nacionalidad
        {
            get => nacionalidad;
            set
            {
                if (value == null || value == "")
                {
                    Console.WriteLine("La nacionalidad no puede estar vacía.");
                    return;
                }
                nacionalidad = value;
            }
        }

        public string Equipo
        {
            get => equipo;
            set
            {
                if (value == null || value.Length < 3)
                {
                    Console.WriteLine("El nombre del equipo debe tener al menos 3 caracteres.");
                    return;
                }
                equipo = value;
            }
        }

        public int Goles
        {
            get => goles;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Los goles no pueden ser negativos.");
                    return;
                }
                goles = value;
            }
        }


        public string Fichado { get => fichado; }
        public int Id { get => id; set => id = value; }

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
            this.fichado = "N";
            this.equipo_actual = null;
            if (Database.Jugadores.Count == 0)
            {
                this.id = 1;
            }
            else
            {
                this.id = Database.Jugadores.Max(x => x.id) + 1;
            }
     
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
        public void Imprimir()
        {
            Console.WriteLine($"ID: {this.id}");
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Edad: {this.edad}");
            Console.WriteLine($"Numero {this.numero}");
            Console.WriteLine($"Posicion {this.posicion}");
            Console.WriteLine($"Nacionalidad {this.nacionalidad} ");
            Console.WriteLine($"Equipo {this.equipo}");
            Console.WriteLine($"Goles {this.Goles}");
            Console.WriteLine($"Fichado {this.fichado}");
            Console.WriteLine($"Equipo Actual: {(this.equipo_actual !=null ? this.equipo_actual.Nombre : "Sin Equipo")}" );
        } 
        public void Fichar(Equipo objEquipoFichado)
        {
            this.fichado = "S";
            this.equipo_actual = objEquipoFichado;
        }

    }
}
