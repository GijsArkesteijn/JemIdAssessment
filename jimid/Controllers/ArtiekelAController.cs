using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace jimid.Controllers
{
    public class ArtiekelAController : Controller
    {
        private readonly MyContext _context;

        public ArtiekelAController(MyContext context)
        {
            _context = context;
        }

        public IQueryable<Artiekel> Sorteer(IQueryable<Artiekel> lijst, string Sorteer){
            if (Sorteer == "naam_oplopend")
                return lijst.OrderBy(s=>s.Naam.ToLower());
            else if(Sorteer == "naam_aflopend"){
                return  lijst.OrderByDescending(s=>s.Naam.ToLower());
            }
            else if(Sorteer =="potmaat_oplopend"){
                return lijst.OrderBy(s=>s.Potmaat);
            }
            
            else if(Sorteer == "potmaat_aflopend"){
                return lijst.OrderByDescending(s=>s.Potmaat);
            }
            else if(Sorteer =="kleur_oplopend"){
                return lijst.OrderBy(s=>s.Kleur.ToLower());
            }
            
            else if(Sorteer == "kleur_aflopend"){
                return lijst.OrderByDescending(s=>s.Kleur.ToLower());
            }
            else if(Sorteer =="productgroep_oplopend"){
                return lijst.OrderBy(s=>s.Productgroep.ToLower());
            }
            
            else if(Sorteer == "productgroep_aflopend"){
                return lijst.OrderByDescending(s=>s.Productgroep.ToLower());
            }
            else{
                return lijst.OrderBy(s=>s.Naam.ToLower());
            }
        }
        

        public IQueryable<Artiekel> Pagineer(IQueryable<Artiekel> lijst, int pagina,int aantal){
            if (pagina <0)
                pagina= 0;
            return lijst.Skip((pagina)*aantal).Take(aantal);
        }

        // GET: Artiekel
        public async Task<IActionResult> Index(string sorteer, string zoek, int pagina)
        {
            if(sorteer==null) 
                sorteer= "naam_oplopend";
            ViewData["sorteer"] = sorteer;
            ViewData["pagina"] = pagina;
            ViewData["heeftVolgende"] = (pagina+1) * 10 < _context.Artiekel.Count();
            ViewData["heeftVorige"] = pagina>0;
            return View(await Pagineer(Sorteer(_context.Artiekel,sorteer), pagina, 10).ToListAsync());
        }

        private bool ArtiekelExists(int id)
        {
            return _context.Artiekel.Any(e => e.Id == id);
        }
    }
}
