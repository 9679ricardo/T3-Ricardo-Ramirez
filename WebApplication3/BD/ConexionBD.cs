using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.BD.Configurations;
using WebApplication3.Models;

namespace WebApplication3.BD
{
    public class ConexionBD : DbContext
    {
        public IDbSet<Pokemon> Pokemons { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<CapturaPokemon> Capturas { get; set; }


        public ConexionBD()
        {
            Database.SetInitializer<ConexionBD>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PokemonConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new CapturaPokemonConfiguration());


        }
    }
}

