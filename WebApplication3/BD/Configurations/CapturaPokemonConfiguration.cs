using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.BD.Configurations
{
    public class CapturaPokemonConfiguration: EntityTypeConfiguration<CapturaPokemon>
    {
        public CapturaPokemonConfiguration()
        {
            ToTable("CapturaPokemon");

            HasKey(o => o.Id);
            HasRequired(o => o.pokemon).WithMany(o => o.usuarios).HasForeignKey(o => o.PokemonId);
            HasRequired(o => o.usuario).WithMany(o => o.pokemons).HasForeignKey(o => o.UsuarioId);


        }
    }
}