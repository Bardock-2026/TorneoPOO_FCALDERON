using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_FCALDERON.Datos
{
    public class TorneoDBContext: DbContext
    {
        //1er paso DbSet para cada clase que se quiera mapear a la base de datos
        public DbSet<Models.Equipo> Equipos { get; set; }
        public DbSet<Models.Jugador> Jugadores { get; set; }
        public DbSet<Models.Partido> Partidos { get; set; }

        //2do paso Configurar la cadena de conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //CADENA CONEXION USUARIO SQL SERVER
            optionsBuilder.UseSqlServer("Server=DESKTOP-DQDC13N\SQLEXPRESS;Database=TORNEO_FCALDERON;User Id=sa;Password=1234;TrustServerCertificate=True;");
            //CADENA CONEXION USUARIO WINDOWS
            //optionsBuilder.UseSqlServer("Server=DESKTOP-DQDC13N\SQLEXPRESS;Database=TORNEO_FCALDERON;Trusted_Connection=True;");


        }
    }
}
