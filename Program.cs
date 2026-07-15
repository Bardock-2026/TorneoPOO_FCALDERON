//using TorneoPOO_EMANOSALVAS.Models;
//using TorneoPOO_FCALDERON.Generales;
//using TorneoPOO_FCALDERON.Models;

//Jugador objJugador1 = new Jugador("Piero Hincapié", 25, 4, "Defensa","Guayaquileño","Emelec",19);

//Jugador objJugador2 = new Jugador("Enner Valencia" ,32, 7, "Delantero","Guayaquileño","Emelec",21);


//Equipo objEquipo1 = new Equipo("Emelec","Guayaquil","Bolillo Gomez",15,"Atahualpa");

//objEquipo1.AgregarJugador(objJugador1);
//objEquipo1.AgregarJugador(objJugador2);



//objEquipo1.ListarPlantilla();

//Jugador objJugador3 = new Jugador("Moiséc Caicedo", 23,5, "Medio Campo","Quiteño","Barcelona",24);

//Jugador objJugador4 = new Jugador("Neiser Reascos",45,24,"Lateral","Quiteño","Barcelona",25);

//Equipo objEquipo2 = new Equipo("Barcelona","Guayaquil","Cairo Shumager",16,"Atahualpa");

//objEquipo2.AgregarJugador(objJugador3);
//objEquipo2.AgregarJugador(objJugador4);



//objEquipo2.ListarPlantilla();

//Partido objPartido1 = new Partido(objEquipo1, objEquipo2, DateTime.Now, "Estadio Modelo", 2, 1, "Carlos Vera");
//objPartido1.MostrarResumen();


using TorneoPOO_FCALDERON.Generales;
using TorneoPOO_FCALDERON.Models;

int opcion = 0;
do
{
    Console.Clear();
    Console.WriteLine("****************Bienvenido al Torneo de Futbol - ISTLC 2026****************");
    Console.WriteLine("Menú de Opciones:");
    Console.WriteLine("1.- Crear Jugadores");
    Console.WriteLine("2.- Listar Jugadores");
    Console.WriteLine("3.- Crear Equipos");
    Console.WriteLine("4.- Crear Partidos");
    Console.WriteLine("5.- Salir");
    Console.WriteLine("");
    Console.Write("Ingrese una opción: ");
    opcion = Convert.ToInt32(Console.ReadLine());


    switch (opcion)
    {
        case 1:
            crearJugador();
            break;
        case 2:
            listarJugadores();
            break;
        case 3:
            crearEquipo();
            break;
        case 4:
            crearPartido();
            break;
        case 5:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
            break;
    }

} while (opcion != 5);

void listarJugadores()
{
    Console.Clear();
    Console.WriteLine("**********Jugadores Creados**********");
    foreach (Jugador jugador in Database.Jugadores)
    {
        jugador.Presenetar();
    }
    Console.ReadLine();
}

void crearPartido()
{
    Console.Clear();
}

void crearEquipo()
{
    Console.Clear();
}

void crearJugador()
{
    Console.Clear();
    Console.WriteLine("**********Crear Jugador**********");
    Console.WriteLine("Ingrese el nombre del jugador: ");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingrese la edad del jugador: ");
    int edad = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el número del jugador: ");
    int numero = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese la posición del jugador: ");
    string posicion = Console.ReadLine();
    Console.WriteLine("Ingrese la nacionalidad del jugador: ");
    string nacionalidad = Console.ReadLine();
    Console.WriteLine("Ingrese el equipo del jugador: ");
    string equipo = Console.ReadLine();
    Console.WriteLine("Ingrese la cantidad de goles del jugador: ");
    int goles = Convert.ToInt32(Console.ReadLine());

    Jugador objJugador = new Jugador(nombre, edad, numero, posicion, nacionalidad, equipo, goles);
    Database.Jugadores.Add(objJugador);
    Console.WriteLine("Jugador creado exitosamente.");
    Console.ReadLine();
}
