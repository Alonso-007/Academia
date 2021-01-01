using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Academia.Dominio.Models;
using Academia.Dados.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Academia.Controllers
{
    [Authorize]
    public class ExerciciosController : Controller
    {
        private readonly IExercicioRepositorio _exercicioRepositorio;
        private readonly ICategoriaExercicioRepositorio _categoriaExercicioRepositorio;
        private readonly IListaExercicioRepositorio _listaExercicioRepositorio;

        public ExerciciosController(IExercicioRepositorio exercicioRepositorio, 
                                    ICategoriaExercicioRepositorio categoriaExercicioRepositorio,
                                    IListaExercicioRepositorio listaExercicioRepositorio)
        {
            _exercicioRepositorio = exercicioRepositorio;
            _categoriaExercicioRepositorio = categoriaExercicioRepositorio;
            _listaExercicioRepositorio = listaExercicioRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _exercicioRepositorio.PegarTodos());
        }

        public async Task<IActionResult> Listagem(int FichaId, int AlunoId)
        {
            ViewData["FichaId"] = FichaId;
            ViewData["AlunoId"] = AlunoId;

            return View(await _exercicioRepositorio.PegarTodos());
        }

        public async Task<IActionResult> AdicionarExercicio(int exercicioId, int frequencia, int repeticoes, int carga, int fichaId)
        {
            if (await _listaExercicioRepositorio.ExercicioExisteNaFicha(exercicioId, fichaId))
            {
                return Json(false);
            }

            ListaExercicio listaExercicio = new ListaExercicio()
            {
                ExercicioId = exercicioId,
                Frequencia = frequencia,
                Repeticoes = repeticoes,
                Carga = carga,
                FichaId = fichaId
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _listaExercicioRepositorio.Inserir(listaExercicio);
                    return Json(true);
                }
                catch (Exception e)
                {
                    return Json(e.Message);
                }
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult Create()
        {
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepositorio.PegarTodos(), "CategoriaExercicioId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExercicioId,Nome,CategoriaExercicioId")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                await _exercicioRepositorio.Inserir(exercicio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepositorio.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var exercicio = await _exercicioRepositorio.PegarPeloId(id);
            if (exercicio == null)
            {
                return NotFound();
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepositorio.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExercicioId,Nome,CategoriaExercicioId")] Exercicio exercicio)
        {
            if (id != exercicio.ExercicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _exercicioRepositorio.Atualizar(exercicio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaExercicioId"] = new SelectList(await _exercicioRepositorio.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _exercicioRepositorio.Excluir(id);
            return Json("Exercício excluído com sucesso");
        }

        public async Task<JsonResult> ExercicioExiste(string nome, int ExercicioId)
        {
            if (ExercicioId == 0)
            {
                if (await _exercicioRepositorio.ExercicioExiste(nome))
                {
                    return Json("Exercício já existe");
                }
                return Json(true);
            }
            else
            {
                if (await _exercicioRepositorio.ExercicioExiste(nome, ExercicioId))
                {
                    return Json("Exercício já existe");
                }
                return Json(true);
            }
        }
    }
}