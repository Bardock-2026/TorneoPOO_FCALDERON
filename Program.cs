using TorneoPOO_FCALDERON.Models;

Jugador objJugador1= new Jugador();
objJugador1.Nombre = "Piero Hincapié";
objJugador1.Numero  = 4;
objJugador1.Posicion = "Defensa";
objJugador1.Edad = 25;

objJugador1.Presenetar();

Jugador objJugador2 = new Jugador();
objJugador2.Nombre = "Enner Valencia";
objJugador2.Numero = 7;
objJugador2.Posicion = "Delantero";
objJugador2.Edad = 32;

objJugador2.Presenetar();


Equipo objEquipo1 = new Equipo();
objEquipo1.Nombre = "Barcelona";
objEquipo1.Ciudad = "Guayaquil";
objEquipo1.Jugadores = new List<Jugador>();

objEquipo1.agregarJugador(objJugador1);
objEquipo1.agregarJugador(objJugador2);
