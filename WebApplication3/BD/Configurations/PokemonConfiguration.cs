using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.BD.Configurations
{
    public class PokemonConfiguration : EntityTypeConfiguration<Pokemon>
    {
    
        public PokemonConfiguration()
        {
            ToTable("Pokemon");

            HasKey(o => o.Id);

        }
    }
}