using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Dados.EFCore;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        AppDbContext _context;
        ILeilaoDao _dao;

        public LeilaoController()
        {
            _context = new AppDbContext();
            _dao = new LeilaoDaoEFCore();
        }

        public IActionResult Index()
        {
            var leiloes = _dao.GetAucttions();

            return View(leiloes);
        } 

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _dao.GetCategories();
            ViewData["Operacao"] = "Inclusão";

            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _context.Leiloes.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _dao.GetCategories();
            ViewData["Operacao"] = "Inclusão";

            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _dao.GetCategories();
            ViewData["Operacao"] = "Edição";
            var leilao = _dao.GetAuctionId(id);
            if (leilao == null) return NotFound();

            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _context.Leiloes.Update(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _dao.GetCategories();
            ViewData["Operacao"] = "Edição";

            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = _dao.GetAuctionId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Rascunho) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = _dao.GetAuctionId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Pregao) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = _dao.GetAuctionId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao == SituacaoLeilao.Pregao) return StatusCode(405);
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _dao.GetAucttions()
                .Where(l => string.IsNullOrWhiteSpace(termo) || 
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );

            return View("Index", leiloes);
        }
    }
}
