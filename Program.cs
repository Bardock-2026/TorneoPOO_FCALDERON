using TorneoPOO_EMANOSALVAS.Models;
using TorneoPOO_FCALDERON.Models;

Jugador objJugador1 = new Jugador();

objJugador1.Nombre = "William Pacho";
objJugador1.Numero = 5;
objJugador1.Posicion = "Defensa";
objJugador1.Edad = 21;


Jugador objJugador2 = new Jugador();

objJugador2.Nombre = "Kendri Paez";
objJugador2.Numero = 10;
objJugador2.Posicion = "Delantero";
objJugador2.Edad = 16;


Equipo objEquipo1 = new Equipo();

objEquipo1.Nombre = "Emelec";
objEquipo1.Ciudad = "Guayaquil";
objEquipo1.Jugadores = new List<Jugador>();

objEquipo1.AgregarJugador(objJugador1);
objEquipo1.AgregarJugador(objJugador2);



objEquipo1.ListarPlantilla();

Jugador objJugador3 = new Jugador();

objJugador3.Nombre = "Alam Franco";
objJugador3.Numero = 8;
objJugador3.Posicion = "Medio Campo";
objJugador3.Edad = 20;


Jugador objJugador4 = new Jugador();

objJugador4.Nombre = "Ivan Hurtado";
objJugador4.Numero = 7;
objJugador4.Posicion = "Lateral";
objJugador4.Edad = 39;


Equipo objEquipo2 = new Equipo();

objEquipo2.Nombre = "Barcelona";
objEquipo2.Ciudad = "Guayaquil";
objEquipo2.Jugadores = new List<Jugador>();

objEquipo2.AgregarJugador(objJugador3);
objEquipo2.AgregarJugador(objJugador4);



objEquipo2.ListarPlantilla();

Partido objPartido1 = new Partido();
objPartido1.Programar(objEquipo1, objEquipo2, DateTime.Now, "Guayaquil");
objPartido1.MostrarResumen();