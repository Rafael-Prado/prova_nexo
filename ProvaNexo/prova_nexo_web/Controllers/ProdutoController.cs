using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using prova_nexo_domain.Domain;
using prova_nexo_service.Service.Interface;
using prova_nexo_web.Models;

namespace prova_nexo_web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;
        private readonly IClienteService _clienteService;
        public ProdutoController(IProdutoService service, IClienteService clienteService)
        {
            _service = service;
            _clienteService = clienteService;
        }
        // GET: Prdotuto
        public ActionResult Index(Guid clienteId)
        {
            var produtos = _service.GetProdutoIdCliente(clienteId);
            var produtodest = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(produtos);
            return View(produtodest);
        }

        // GET: Prdotuto/Details/5
        public ActionResult Details(Guid id)
        {
            var produto = _service.GetProdutoId(id);
            var produtodest = Mapper.Map<Produto, ProdutoModel>(produto);
            return View(produtodest);
        }

        // GET: Prdotuto/Create
        public ActionResult Create()
        {
            var clientes = _clienteService.GetClienteList();
            var clientedest = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(clientes);
            ViewBag.Clientes = new SelectList(clientedest, "Id", "Nome");
            return View();
        }

        // POST: Prdotuto/Create
        [HttpPost]
        public ActionResult Create(ProdutoModel produtoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produtodest = Mapper.Map<ProdutoModel, Produto>(produtoModel);
                    var result = _service.SalvarProduto(produtodest);
                    if (result)
                    {
                        return RedirectToAction("Index", new {clienteId = produtoModel.ClienteId});
                    }
                }
                var clientes = _clienteService.GetClienteList();
                var clientedest = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(clientes);
                ViewBag.Clientes = new SelectList(clientedest, "Id", "Nome", produtoModel.ClienteId);
                return View(produtoModel);
            }
            catch (Exception e)
            {
                var bb = e;
                var clientes = _clienteService.GetClienteList();
                var clientedest = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(clientes);
                ViewBag.Clientes = new SelectList(clientedest, "Id", "Nome", produtoModel.ClienteId);
                return View(produtoModel);
            }
        }

        // GET: Prdotuto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Prdotuto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prdotuto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prdotuto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
