using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.BD;
using WebApplication3.Models;
using WebApplication3.Servicios;

namespace WebApplication3.Controllers
{
    public class PokemonController : Controller
    {
        private ConexionBD entidades = new ConexionBD();
        // GET: Pokemon
        public ActionResult Index(int? id)
        {
            ViewBag.usuario = id;
            return View(entidades.Pokemons.ToList());
        }


        public ActionResult IndexBus(string nom, int? id)
        {
            ViewBag.usuario = id;
            var buscando = entidades.Pokemons.Where(o => o.Nombre == nom).FirstOrDefault();
            return PartialView(buscando);
        }


        [HttpGet]
        public ActionResult Crear()
        {
            List<string> tipos = new List<string>();
            tipos.Add("Agua");
            tipos.Add("Fuego");
            tipos.Add("Planta");
            tipos.Add("Electrico");
            tipos.Add("Roca");

            ViewBag.tipos = tipos;
            return View(new Pokemon());
        }
        [HttpPost]
        public ActionResult Crear(Pokemon pokemon, HttpPostedFileBase file)
        {
            List<string> tipos = new List<string>();
            tipos.Add("Agua");
            tipos.Add("Fuego");
            tipos.Add("Planta");
            tipos.Add("Electrico");
            tipos.Add("Roca");

            ViewBag.tipos = tipos;




            if (file != null && file.ContentLength > 0)
            {
                string ruta = Path.Combine(Server.MapPath("~/imagenes"), Path.GetFileName(file.FileName));
                file.SaveAs(ruta);
                pokemon.Imagen = "/imagenes/" + Path.GetFileName(file.FileName);
            }
            Validar(pokemon);
            if (ModelState.IsValid)
            {

                entidades.Pokemons.Add(pokemon);
                entidades.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Usuario());

        }
        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            var aux = new Usuario();
            aux = entidades.Usuarios.Where(o => o.Username == user.Username).FirstOrDefault();
            if (aux == null)
            {

                ModelState.AddModelError("Username", "ES INVALIDO");
            }
            else
            {
                if (aux.Password != user.Password)
                {
                    ModelState.AddModelError("Password", "ES INVALIDO");
                }
            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(aux.Username, false);
                System.Web.HttpContext.Current.Session["Usuario"] = aux;
                return RedirectToAction("Index", new { id = aux.Id });
            }


            return View(user);

        }
        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

        public ActionResult Capturar(int idPokemon, int idUsuario, int tipo)
        {

            ProbabilidadCaptura proba = new ProbabilidadCaptura();
            switch (tipo)
            {
                case 1:
                    proba.ConPokeball();
                    break;
                case 2:
                    proba.ConSuperball();
                    break;
                case 3:
                    proba.ConUltraball();
                    break;
                case 4:
                    proba.ConMasterball();
                    break;

            }

            if (proba.LoCapture())
            {

                var cap = new CapturaPokemon();
                cap.PokemonId = idPokemon;
                cap.UsuarioId = idUsuario;
                ViewBag.captura = "Pokemon capturado";
                entidades.Capturas.Add(cap);
                entidades.SaveChanges();
            }
            else
            {
                ViewBag.captura = "Pokemon se ha escapado";

            }
            ViewBag.usuario = idUsuario;
            return View();
        }

        public ActionResult MisPokemon(int id)
        {
            ViewBag.usuario = id;
            var miscap = entidades.Capturas.Where(o => o.UsuarioId == id).ToList();
            List<Pokemon> mispok = new List<Pokemon>();
            foreach (var aux in miscap)
            {
                var ex = entidades.Pokemons.Where(o => o.Id == aux.PokemonId).FirstOrDefault();
                if (ex != null)
                {
                    mispok.Add(ex);
                }
            }
            return View(mispok);
        }



        public void Validar(Pokemon p)
        {
            var aux = entidades.Pokemons.Where(o => o.Nombre == p.Nombre).FirstOrDefault();
            if (aux != null)
            {
                ModelState.AddModelError("Nombre", "El Nombre debe ser unico");
            }
            if (string.IsNullOrEmpty(p.Nombre))
            {
                ModelState.AddModelError("Nombre", "El Nombre es obligatorio");
            }
            if (p.Tipo == "no")
            {
                ModelState.AddModelError("Tipo", "El Tipo es obligatorio");
            }
            if (string.IsNullOrEmpty(p.Imagen))
            {
                ModelState.AddModelError("Imagen", "La es obligatoria");
            }
        }

    }
}