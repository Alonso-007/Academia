using Academia.Dados.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Academia.ViewComponents
{
    public class DadosAlunoViewComponent : ViewComponent
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public DadosAlunoViewComponent(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync(int AlunoId)
        {
            return View(await _alunoRepositorio.PegrDadosAlunoPeloId(AlunoId));
        }
    }
}
