using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;
 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    public class EditRutasModel : PageModel
    {
        private readonly RepositorioRutas repositorioRutas;
        [BindProperty]
        public Rutas Ruta {get;set;}
      
        public EditRutasModel(RepositorioRutas repositorioRutas) 
        {
            this.repositorioRutas = repositorioRutas;
        }

        public IActionResult OnGet(int RutaId)
        {
            Ruta=repositorioRutas.GetRutaWithId(RutaId);
            return Page();
 
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Ruta.id>0)
            {
            Ruta = repositorioRutas.Update(Ruta);
            }
            return RedirectToPage("./List");
        }



    }
}
