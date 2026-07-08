using TorneoPOO_FCALDERON.Models;

public class Equipo
{
    public string Nombre { get; set; }
    public string Ciudad { get; set; }
    public List<Jugador> Jugadores { get; set; }


    //Constructor
    public Equipo(string nomnbre, string ciudad) 
    { 
        this.Nombre = nomnbre;
        this.Ciudad = ciudad;
        this.Jugadores = new List<Jugador>();
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
   
}

