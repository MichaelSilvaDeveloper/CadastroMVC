using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _iContatoRepositorio;

        public ContatoController(IContatoRepositorio iContatoRepositorio)
        {
            _iContatoRepositorio = iContatoRepositorio;
        }

        public IActionResult Index()
        {
            var contato = _iContatoRepositorio.BuscarTodos();
            return View(contato);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _iContatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _iContatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            _iContatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _iContatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _iContatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

    }
}
