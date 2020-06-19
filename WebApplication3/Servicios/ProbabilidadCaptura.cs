using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.estrategia;

namespace WebApplication3.Servicios
{
    public class ProbabilidadCaptura
    {
        public Estrategia est;

        public Estrategia ConPokeball()
        {
            est = new Pokeball();
            return est;
        }
        public Estrategia ConSuperball()
        {
            est = new Superball();
            return est;
        }
        public Estrategia ConUltraball()
        {
            est = new Ultraball();
            return est;
        }
        public Estrategia ConMasterball()
        {
            est = new Masterball();
            return est;
        }

        public bool LoCapture()
        {
            return est.PuedoCapturarlo();
        }

    }
}