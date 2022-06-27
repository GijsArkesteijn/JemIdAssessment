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
            if(sorteer==null) sorteer= "naam_oplopend";
            ViewData["sorteer"] = sorteer;
            ViewData["pagina"] = pagina;
            ViewData["heeftVolgende"] = (pagina+1) * 10 < _context.Artiekel.Count();
            ViewData["heeftVorige"] = pagina>0;
            return View(await Pagineer(Sorteer(_context.Artiekel,sorteer), pagina, 10).ToListAsync());
        }


        // GET: ArtiekelA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiekel = await _context.Artiekel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artiekel == null)
            {
                return NotFound();
            }

            return View(artiekel);
        }

        // GET: ArtiekelA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtiekelA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Potmaat,Planthoogte,Kleur,Productgroep")] Artiekel artiekel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artiekel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artiekel);
        }

        // GET: ArtiekelA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiekel = await _context.Artiekel.FindAsync(id);
            if (artiekel == null)
            {
                return NotFound();
            }
            return View(artiekel);
        }

        // POST: ArtiekelA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Potmaat,Planthoogte,Kleur,Productgroep")] Artiekel artiekel)
        {
            if (id != artiekel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artiekel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtiekelExists(artiekel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(artiekel);
        }

        // GET: ArtiekelA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiekel = await _context.Artiekel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artiekel == null)
            {
                return NotFound();
            }

            return View(artiekel);
        }

        // POST: ArtiekelA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artiekel = await _context.Artiekel.FindAsync(id);
            _context.Artiekel.Remove(artiekel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtiekelExists(int id)
        {
            return _context.Artiekel.Any(e => e.Id == id);
        }
    }
}
