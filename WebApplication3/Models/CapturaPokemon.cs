using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CapturaPokemon
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int UsuarioId { get; set; }

        public Pokemon pokemon { get; set; }
        public Usuario usuario { get; set; }

    }
}