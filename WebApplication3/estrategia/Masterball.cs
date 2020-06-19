using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.estrategia
{
    public class Masterball : Estrategia
    {
        public bool PuedoCapturarlo()
        {
            return true;
        }
    }
}