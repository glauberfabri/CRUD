using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirst.Models;

namespace DBFirst.Controllers
{
    public class CadastroesController : Controller
    {
        private readonly CRUDDBContext _context;

        public CadastroesController(CRUDDBContext context)
        {
            _context = context;
        }

        // GET: Cadastroes
        public async Task<IActionResult> Index()
        {
              return _context.Cadastros != null ? 
                          View(await _context.Cadastros.ToListAsync()) :
                          Problem("Entity set 'CRUDDBContext.Cadastros'  is null.");
        }

        // GET: Cadastroes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .FirstOrDefaultAsync(m => m.Cnpj == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cnpj,RazaoSocial,NomeFantasia,Email,Telefone,TelefoneComercial,Celular,Logradouro,Numero,Complemento,Bairro,Cidade,Estado,Cep,NomeContato")] Cadastro cadastro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cadastro);
                    await _context.SaveChangesAsync();
                    TempData["MessagemSucesso"] = "Cadastro Adicionado com Sucesso";
                    return RedirectToAction(nameof(Index));
                }
                
                return View(cadastro);

            }
            catch (Exception erro)
            {

                TempData["MessagemErro"] = $"Ops, não foi possível cadastrar!{ erro.Message}";
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: Cadastroes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            try
            {
                if (id == null || _context.Cadastros == null)
                {
                    return NotFound();
                }

                var cadastro = await _context.Cadastros.FindAsync(id);
                TempData["MessagemSucesso"] = "Cadastro Editado com Sucesso";
                if (cadastro == null)
                {
                    return NotFound();
                }
                TempData["MessagemSucesso"] = "Cadastro Editado com Sucesso";
                return View(cadastro);

            }
            catch (Exception erro)
            {

                TempData["MessagemErro"] = $"Ops, não foi possível Editar!{erro.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Cadastroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Cnpj,RazaoSocial,NomeFantasia,Email,Telefone,TelefoneComercial,Celular,Logradouro,Numero,Complemento,Bairro,Cidade,Estado,Cep,NomeContato")] Cadastro cadastro)
        {
            if (id != cadastro.Cnpj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.Cnpj))
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
            return View(cadastro);
        }

        // GET: Cadastroes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .FirstOrDefaultAsync(m => m.Cnpj == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Cadastros == null)
            {
                return Problem("Entity set 'CRUDDBContext.Cadastros'  is null.");
            }
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro != null)
            {
                _context.Cadastros.Remove(cadastro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(long id)
        {
          return (_context.Cadastros?.Any(e => e.Cnpj == id)).GetValueOrDefault();
        }
    }
}
