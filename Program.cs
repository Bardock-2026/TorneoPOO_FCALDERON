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

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TorneoPOO_FCALDERON.Datos;
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
    Console.WriteLine("3.- Buscar Jugador");
    Console.WriteLine("4.- Actualizar Jugador");
    Console.WriteLine("5.- Eliminar Jugador");
    Console.WriteLine("6.- Crear Equipos");
    Console.WriteLine("7.- Listar Equipos");
    Console.WriteLine("8.- Buscar Equipos");
    Console.WriteLine("9.- Actualizar Equipos");// ya esta el deber 
    Console.WriteLine("10.- Elminar Equipos"); // deber /ya esta
    Console.WriteLine("11.- Crear Partidos");// deber / ya esta
    Console.WriteLine("12.- Listar Partidos");// deber / ya esta
    Console.WriteLine("13.- Buscar Partido");// deber /ya esta
    Console.WriteLine("14.- Actualizar Partido");// deber /Ya esta
    Console.WriteLine("15.- Eliminar Partido");// deber  /Ya esta
    Console.WriteLine("16.- Salir");
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
            BuscarJugador();
            break;
        case 4:
            ActualizarJugador();
            break;
        case 5:
            EliminarJugador();
            break;
        case 6:
            crearEquipo();
            break;
        case 7:
            listarEquipo();
            break;
        case 8:
            buscarEquipo();
            break;
        case 9:
            actualizarEquipo();
            break;
        case 10:
            eliminarEquipo();
            break;
        case 11:
            crearPartido();
            break;
        case 12:
            listarPartido();
            break;
        case 13:
            buscarPartido();
            break;
        case 14:
            actualizarPartido();
            break;
        case 15:
            eliminarPartido();
            break;
        case 16:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
            break;
    }

} while (opcion != 16);




// CRUD PARTIDO
void crearPartido()
{
    Console.Clear();
    Console.WriteLine("**********Crear Partido**********");

    Console.WriteLine("Ingrese el nombre del equipo local: ");
    string nombreLocal = Console.ReadLine();

    Console.WriteLine("Ingrese el nombre del equipo visitante: ");
    string nombreVisitante = Console.ReadLine();

    Console.WriteLine("Ingrese la fecha del partido (dd/mm/yyyy): ");
    DateTime fecha = Convert.ToDateTime(Console.ReadLine());

    Console.WriteLine("Ingrese el lugar del partido: ");
    string lugar = Console.ReadLine();

    Console.WriteLine("Ingrese el árbitro del partido: ");
    string arbitro = Console.ReadLine();

    using (var context = new TorneoDBContext())
    {
        Equipo equipoLocal = context.Equipos.FirstOrDefault(e => e.Nombre == nombreLocal);
        Equipo equipoVisitante = context.Equipos.FirstOrDefault(e => e.Nombre == nombreVisitante);

        Partido objPartido = new Partido(equipoLocal, equipoVisitante, fecha, lugar, 0, 0, arbitro);
        context.Partidos.Add(objPartido);
        context.SaveChanges();
    }

    Console.WriteLine("Partido creado exitosamente!!");
    Console.ReadLine();
}

void listarPartido()
{
    Console.Clear();
    Console.WriteLine("**********Partidos Creados**********");
    using (var context = new TorneoDBContext())
    {
        foreach (Partido partido in context.Partidos.Include(p => p.Local).Include(p => p.Visitante))
        {
            partido.Imprimir();
            Console.WriteLine("_____________________________________");
        }
    }
    Console.ReadLine();
}

void buscarPartido()
{
    Console.Clear();
    Console.WriteLine("**********Buscar Partido**********");
    Console.WriteLine("Ingrese el ID del partido: ");
    int id_Ingresada = Convert.ToInt32(Console.ReadLine());

    using (var context = new TorneoDBContext())
    {
        Partido objPartido = context.Partidos
            .Include(p => p.Local)
            .Include(p => p.Visitante)
            .FirstOrDefault(p => p.Id == id_Ingresada);

        if (objPartido != null)
        {
            Console.WriteLine("Partido Encontrado!!");
            objPartido.Imprimir();
        }
        else
        {
            Console.WriteLine("Partido NO encontrado....");
        }
    }
    Console.ReadLine();
}

void actualizarPartido()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Partido**********");
    Console.WriteLine("Ingrese el ID del partido a actualizar: ");
    int id_Ingresada = Convert.ToInt32(Console.ReadLine());

    using (var context = new TorneoDBContext())
    {
        Partido objPartido = context.Partidos
            .Include(p => p.Local)
            .Include(p => p.Visitante)
            .FirstOrDefault(p => p.Id == id_Ingresada);

        if (objPartido != null)
        {
            Console.WriteLine("Partido Encontrado!!!");
            Console.WriteLine("_____________________________________");
            objPartido.Imprimir();
            Console.WriteLine("_____________________________________");

            Console.WriteLine("Ingrese el nuevo nombre del equipo local: ");
            string nombreLocal = Console.ReadLine();
            Equipo equipoLocal = context.Equipos.FirstOrDefault(e => e.Nombre == nombreLocal);
            if (equipoLocal != null) objPartido.Local = equipoLocal;

            Console.WriteLine("Ingrese el nuevo nombre del equipo visitante: ");
            string nombreVisitante = Console.ReadLine();
            Equipo equipoVisitante = context.Equipos.FirstOrDefault(e => e.Nombre == nombreVisitante);
            if (equipoVisitante != null) objPartido.Visitante = equipoVisitante;

            Console.WriteLine("Ingrese la nueva fecha del partido (dd/mm/yyyy): ");
            objPartido.Fecha = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo lugar del partido: ");
            objPartido.Lugar = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo árbitro del partido: ");
            objPartido.Arbitro = Console.ReadLine();

            Console.WriteLine("Ingrese los goles del equipo local: ");
            objPartido.GolesLocal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese los goles del equipo visitante: ");
            objPartido.GolesVisitante = Convert.ToInt32(Console.ReadLine());

            context.SaveChanges();
            Console.WriteLine("Partido actualizado exitosamente!!");
        }
        else
        {
            Console.WriteLine("Partido NO encontrado...");
        }
    }
    Console.ReadLine();
}

void eliminarPartido()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Partido**********");
    Console.WriteLine("Ingrese el ID del partido a eliminar: ");
    int id_Ingresada = Convert.ToInt32(Console.ReadLine());

    using (var context = new TorneoDBContext())
    {
        Partido objPartido = context.Partidos
            .Include(p => p.Local)
            .Include(p => p.Visitante)
            .FirstOrDefault(p => p.Id == id_Ingresada);

        if (objPartido != null)
        {
            objPartido.Imprimir();
            Console.WriteLine("¿Estás seguro que quieres eliminar este partido? S/N:");
            if (Console.ReadLine().ToUpper() == "S")
            {
                context.Partidos.Remove(objPartido);
                context.SaveChanges();
                Console.WriteLine("Partido eliminado exitosamente!!");
            }
            else
            {
                Console.WriteLine("Operación cancelada!!");
            }
        }
        else
        {
            Console.WriteLine("Partido NO encontrado!!");
        }
    }
    Console.ReadLine();
}
//CRUD EQUIPO 
void crearEquipo()
{
    Console.Clear();
    Console.WriteLine("***************Crear Equipo******************");
    Console.WriteLine("Ingrese el nombre del equipo: ");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingrese la ciudad del equipo: ");
    string ciudad = Console.ReadLine();
    Console.WriteLine("Ingrese el entrenador: ");
    string entrenador = Console.ReadLine();
    Console.WriteLine("Ingrese la cantidad de títulos del equipo: ");
    int titulos = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el estadio donde juega el equipo: ");
    string estadio = Console.ReadLine();

    Equipo objEquipo = new Equipo(nombre, ciudad, entrenador, titulos, estadio);

    using (var context = new TorneoDBContext())
    {
        context.Equipos.Add(objEquipo);
        context.SaveChanges();
    }

    Console.WriteLine("Equipo creado exitosamente!!");
    Console.ReadLine();
}

void listarEquipo()
{
    Console.Clear();
    Console.WriteLine("**********Equipos Creados**********");
    using (var context = new TorneoDBContext())
    {
        foreach (Equipo equipo in context.Equipos)
        {
            equipo.Imprimir();
            Console.WriteLine("_____________________________________");
        }
    }
    Console.ReadLine();
}

void buscarEquipo()
{
    Console.Clear();
    Console.WriteLine("**********Buscar Equipo**********");
    Console.WriteLine("Ingrese el nombre del equipo a buscar: ");
    string nombreIngresado = Console.ReadLine();

    using (var context = new TorneoDBContext())
    {
        Equipo objEquipo = context.Equipos
            .Where(e => e.Nombre == nombreIngresado)
            .FirstOrDefault();

        if (objEquipo != null)
        {
            Console.WriteLine("Equipo Encontrado!!");
            Console.WriteLine("_____________________________________");
            objEquipo.Imprimir();
            objEquipo.ListarPlantilla();
        }
        else
        {
            Console.WriteLine("Equipo NO encontrado....");
            Console.WriteLine("_____________________________________");
        }
    }
    Console.ReadLine();
}

void actualizarEquipo()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Equipo***********");
    Console.WriteLine("Ingrese el nombre del equipo a actualizar: ");
    string nombreIngresado = Console.ReadLine();

    using (var context = new TorneoDBContext())
    {
        Equipo objEquipo = context.Equipos
            .Where(e => e.Nombre.ToUpper() == nombreIngresado.ToUpper())
            .FirstOrDefault();

        if (objEquipo != null)
        {
            Console.WriteLine("Equipo Encontrado!!!");
            Console.WriteLine("_____________________________________");
            objEquipo.Imprimir();
            Console.WriteLine("_____________________________________");

            Console.WriteLine("Ingrese el nuevo nombre del equipo: ");
            objEquipo.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva ciudad del equipo: ");
            objEquipo.Ciudad = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo entrenador: ");
            objEquipo.Entrenador = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad de títulos del equipo: ");
            objEquipo.Titulos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el estadio donde juega el equipo: ");
            objEquipo.Estadio = Console.ReadLine();

            context.SaveChanges();
            Console.WriteLine("Equipo actualizado exitosamente!!");
        }
        else
        {
            Console.WriteLine("Equipo NO encontrado...");
        }
    }
    Console.ReadLine();
}

void eliminarEquipo()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Equipo**********");
    Console.WriteLine("Ingrese el nombre del equipo a eliminar: ");
    string nombreIngresado = Console.ReadLine();

    using (var context = new TorneoDBContext())
    {
        Equipo objEquipo = context.Equipos
            .Where(e => e.Nombre == nombreIngresado)
            .FirstOrDefault();

        if (objEquipo != null)
        {
            Console.WriteLine("_____________________________________");
            objEquipo.Imprimir();
            Console.WriteLine("_____________________________________");

            Console.WriteLine($"¿Estás seguro que quieres eliminar el equipo {objEquipo.Nombre}? S/N:");
            if (Console.ReadLine().ToUpper() == "S")
            {
                context.Equipos.Remove(objEquipo);
                context.SaveChanges();
                Console.WriteLine("Equipo eliminado exitosamente!!");
                Console.WriteLine("_____________________________________");
            }
            else
            {
                Console.WriteLine("Operación cancelada!!");
                Console.WriteLine("_____________________________________");
            }
        }
        else
        {
            Console.WriteLine("Equipo NO encontrado!!");
            Console.WriteLine("_____________________________________");
        }
    }
    Console.ReadLine();
}
// CRUD JUGADOR
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

    using (var context = new TorneoDBContext())
    {
        context.Jugadores.Add(objJugador);
        context.SaveChanges();
    }
        
    Console.WriteLine("Jugador creado exitosamente.");
    Console.ReadLine();
}

void listarJugadores()
{
    Console.Clear();
    Console.WriteLine("**********Jugadores Creados**********");
    var contex = new TorneoDBContext();
    foreach (Jugador jugador in contex.Jugadores)
    {
        jugador.Imprimir();
        Console.WriteLine("_____________________________________");
    }
    Console.ReadLine();
}
void BuscarJugador()
{
    Console.Clear();
    Console.WriteLine("**********Buscar Jugador**********");
    Console.WriteLine("Ingrese el nombre del jugador a buscar: ");
    string nombreIngresado = Console.ReadLine();
    var contex = new TorneoDBContext();
    Jugador objJugador = contex.Jugadores.Where(j => j.Nombre == nombreIngresado).FirstOrDefault();
    if (objJugador != null)
    {
        Console.WriteLine("Jugador Encontrado!!");
        Console.WriteLine("_____________________________________");
        objJugador.Imprimir();
    }
    else
    {
        Console.Write("Jugador NO encontrado.... ");
        Console.WriteLine("_____________________________________");
    }
    Console.ReadLine();
}
void ActualizarJugador()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Jugador**********");
    Console.WriteLine("Ingrese el nombre del jugador a buscar: ");
    string nombreIngresado = Console.ReadLine();
    var contex = new TorneoDBContext();
    Jugador objJugador = contex.Jugadores.Where(j => j.Nombre == nombreIngresado).FirstOrDefault();


    if (objJugador != null)
    {
        Console.WriteLine("Jugador Encontrado!!!");
        Console.WriteLine("_____________________________________");
        objJugador.Imprimir();
        Console.WriteLine("_____________________________________");

        Console.WriteLine("Ingrese el nuevo nombre del jugador: ");
        objJugador.Nombre = Console.ReadLine();

        Console.WriteLine("Ingrese la nueva edad del jugador: ");
        objJugador.Edad = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo número del jugador: ");
        objJugador.Numero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese la nueva posición del jugador: ");
        objJugador.Posicion = Console.ReadLine();

        Console.WriteLine("Ingrese la nueva nacionalidad del jugador: ");
        objJugador.Nacionalidad = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo equipo del jugador: ");
        objJugador.Equipo = Console.ReadLine();

        Console.WriteLine("Ingrese la nueva cantidad de goles del jugador: ");
        objJugador.Goles = Convert.ToInt32(Console.ReadLine());
        contex.SaveChanges();

        Console.WriteLine("Jugador actualizado exitosamente!!");
    }
    else
    {
        Console.WriteLine("Jugador NO encontrado...");
    }
    Console.ReadLine();
}
void EliminarJugador()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Jugador**********");
    Console.WriteLine("Ingrese el nombre del jugador a eliminar: ");
    string nombreIngresado = Console.ReadLine();
    var contex = new TorneoDBContext();
    Jugador objJugador = contex.Jugadores.Where(j => j.Nombre == nombreIngresado).FirstOrDefault();

    if (objJugador != null)
    {
        Console.WriteLine("_____________________________________");
        objJugador.Imprimir();
        Console.WriteLine("_____________________________________");
        Console.WriteLine($"Estas seguro que quieres eliminar a este jugador{objJugador.Nombre}??  S/N:");
        if (Console.ReadLine().ToUpper() == "S")
        {
            contex.Jugadores.Remove(objJugador);
            contex.SaveChanges();
            Console.WriteLine("Jugador eliminado exitosamente!!");
        }
        else
        {
            Console.WriteLine("Operacion Cancelada!!");
        }

    }
    else
    {
        Console.WriteLine("Jugador NO encontrado!!");

    }
    Console.ReadLine();

}