using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);

            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _contatoRepositorio.Editar(contato);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            bool apagou = _contatoRepositorio.Apagar(id);

            if (!apagou)
            {
                throw new Exception("Erro ao apagar contato");
            }

            return RedirectToAction("Index");
        }
    }
}
