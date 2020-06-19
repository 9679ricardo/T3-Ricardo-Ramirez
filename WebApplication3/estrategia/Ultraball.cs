using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.estrategia
{
    public class Ultraball : Estrategia
    {
        public bool PuedoCapturarlo()
        {
            Random ramdom = new Random();
            return ramdom.Next(1, 3) == 1;
        }
    }
}