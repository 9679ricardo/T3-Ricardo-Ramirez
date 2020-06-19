using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.estrategia
{
    public class Pokeball : Estrategia
    {
        public bool PuedoCapturarlo()
        {
            Random ramdom = new Random();
            return ramdom.Next(1, 6) == 1;
        }
    }
}