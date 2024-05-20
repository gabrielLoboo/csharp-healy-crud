using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Healy_API.Data;
using Healy_API.Models;

namespace Healy_API.Controllers
{
    public class ProfissionaisSaudeController : Controller
    {
        private readonly DataContext _context;

        public ProfissionaisSaudeController(DataContext context)
        {
            _context = context;
        }

        // GET: ProfissionaisSaude
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfissionaisSaude.ToListAsync());
        }

        // GET: ProfissionaisSaude/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalSaude = await _context.ProfissionaisSaude
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionalSaude == null)
            {
                return NotFound();
            }

            return View(profissionalSaude);
        }

        // GET: ProfissionaisSaude/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfissionaisSaude/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,AreaAtuacao")] ProfissionalSaude profissionalSaude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissionalSaude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profissionalSaude);
        }

        // GET: ProfissionaisSaude/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalSaude = await _context.ProfissionaisSaude.FindAsync(id);
            if (profissionalSaude == null)
            {
                return NotFound();
            }
            return View(profissionalSaude);
        }

        // POST: ProfissionaisSaude/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,AreaAtuacao")] ProfissionalSaude profissionalSaude)
        {
            if (id != profissionalSaude.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissionalSaude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionalSaudeExists(profissionalSaude.Id))
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
            return View(profissionalSaude);
        }

        // GET: ProfissionaisSaude/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalSaude = await _context.ProfissionaisSaude
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionalSaude == null)
            {
                return NotFound();
            }

            return View(profissionalSaude);
        }

        // POST: ProfissionaisSaude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profissionalSaude = await _context.ProfissionaisSaude.FindAsync(id);
            if (profissionalSaude != null)
            {
                _context.ProfissionaisSaude.Remove(profissionalSaude);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalSaudeExists(int id)
        {
            return _context.ProfissionaisSaude.Any(e => e.Id == id);
        }
    }
}
