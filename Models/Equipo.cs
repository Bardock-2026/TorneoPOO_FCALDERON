using TorneoPOO_FCALDERON.Models;

public class Equipo
{
    private string nombre;
    private string ciudad;
    private List<Jugador> jugadores;
    private string entrenador;
    private int titulos;
    private string estadio;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Ciudad { get => ciudad; set => ciudad = value; }
    public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
    public string Entrenador
    {
        get => entrenador;
        set
        {
            if (value == null || value == "")
            {
                Console.WriteLine("El nombre del entrenador no puede estar vacío.");
                return;
            }
            entrenador = value;
        }
    }

    public int Titulos
    {
        get => titulos;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("La cantidad de títulos no puede ser negativa.");
                return;
            }
            titulos = value;
        }
    }

    public string Estadio
    {
        get => estadio;
        set
        {
            if (value == null || value == "")
            {
                Console.WriteLine("El nombre del estadio no puede estar vacío.");
                return;
            }
            estadio = value;
        }
    }


    //Constructor
    public Equipo(string nombre, string ciudad, string entrenador, int titulos, string estadio)
    {
        if (nombre == null || nombre.Length == 0)
        {
            throw new Exception("El nombre del equipo no puede estar vacío");
        }

        if (ciudad == null || ciudad.Length == 0)
        {
            throw new Exception("La ciudad del equipo no puede estar vacía");
        }

        this.Nombre = nombre;
        this.Ciudad = ciudad;
        this.Jugadores = new List<Jugador>();
        this.entrenador = entrenador;
        this.titulos = titulos;
        this.estadio = estadio;
    }



    //Acciones: Agregar jugador, listar plantilla.

    public void AgregarJugador(Jugador objJugador)
    {
        this.Jugadores.Add(objJugador);
        Console.WriteLine($"Jugador {objJugador.Nombre} agregado correctamente!!");
    }

    public void ListarPlantilla()
    {
        Console.WriteLine($"La lista de jugadores del equipo {this.Nombre} de la ciudad de {this.Ciudad} es: ");
        foreach(Jugador objJugador in Jugadores)
        {
            objJugador.Presenetar();

        }
    }
    public bool ImpedirAgregarJugadorNulo(Jugador jugador)
    {
        if (jugador == null)
        {
            return false;
        }
        this.Jugadores.Add(jugador);
        return true;
    }
}

