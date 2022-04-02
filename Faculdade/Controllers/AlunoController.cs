using Faculdade.Data;
using Faculdade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Faculdade.Controllers
{
    public class AlunoController : Controller
    {
        public readonly AppCont _appCont;

        public AlunoController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var alltask = _appCont.Alunos.ToList();
            return View(alltask);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _appCont.Alunos.FirstOrDefaultAsync(m => m.Id == id);
            if(aluno == null)
            {
                return NotFound();
            }

            return View(aluno);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Curso, Endereco, Tel, dataNascimento")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(aluno);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _appCont.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Curso, Endereco, Tel, dataNascimento")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appCont.Update(aluno);
                    await _appCont.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExist(aluno.Id))
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
            return View(aluno);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _appCont.Alunos.FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _appCont.Alunos.FindAsync(id);
            _appCont.Alunos.Remove(aluno);
            await _appCont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExist(int id)
        {
            return _appCont.Alunos.Any(e => e.Id == id);
        }
    }
}
