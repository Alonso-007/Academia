using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Academia.Dominio.Models;
using Academia.Dados.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Academia.Controllers
{
    [Authorize]
    public class CategoriasExerciciosController : Controller
    {
        private readonly ICategoriaExercicioRepositorio _categoriaExercicioRepositorio;

        public CategoriasExerciciosController(ICategoriaExercicioRepositorio categoriaExercicioRepositorio)
        {
            _categoriaExercicioRepositorio = categoriaExercicioRepositorio;
        }

        // GET: CategoriasExercicios
        public IActionResult Index()
        {
            return View(_categoriaExercicioRepositorio.PegarTodos());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaExercicioId,Nome")] CategoriaExercicio categoriaExercicio)
        {
            if (ModelState.IsValid)
            {
                await _categoriaExercicioRepositorio.Inserir(categoriaExercicio);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaExercicio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoriaExercicio = await _categoriaExercicioRepositorio.PegarPeloId(id);
            if (categoriaExercicio == null)
            {
                return NotFound();
            }
            return View(categoriaExercicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaExercicioId,Nome")] CategoriaExercicio categoriaExercicio)
        {
            if (id != categoriaExercicio.CategoriaExercicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoriaExercicioRepositorio.Atualizar(categoriaExercicio);

                return RedirectToAction(nameof(Index));
            }
            return View(categoriaExercicio);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _categoriaExercicioRepositorio.Excluir(id);
            return Json("Categoria excluída com sucesso");
        }

        public async Task<JsonResult> CategoriaExiste(string nome, int CategoriaExercicioId)
        {
            if (CategoriaExercicioId == 00)
            {
                if (await _categoriaExercicioRepositorio.CategoriaExiste(nome))
                {
                    return Json("Categoria já existe");
                }
                return Json(true);
            }
            else
            {
                if(await _categoriaExercicioRepositorio.CategoriaExiste(nome, CategoriaExercicioId))
                {
                    return Json("Categoria já existe");
                }
                return Json(true);
            }
        }

    }
}