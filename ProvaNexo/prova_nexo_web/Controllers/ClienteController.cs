
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using prova_nexo_domain.Domain;
using prova_nexo_service.Service.Interface;
using prova_nexo_web.Models;

namespace prova_nexo_web.Controllers
{
    public class ClienteController: Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }
        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = _service.GetClienteList();
            var clintedest = Mapper.Map< IEnumerable<Cliente>, IEnumerable<ClienteModel>>(clientes);
            
            return View(clintedest);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Guid id)
        {
            var cliente = _service.GetClienteId(id);
            var clintedest = Mapper.Map<Cliente, ClienteModel>(cliente);
            var produtos = clintedest.ProdutoList.Count();
            TimeSpan intervalo = DateTime.Now.Date - Convert.ToDateTime(clintedest.DataCadastro);
            if (intervalo.Days/365 > 5)
            {
                ViewBag.statusMaster = "Prata";
            }
            

            if (produtos >= 2000 && produtos < 5000)
            {
                ViewBag.statusMaster = "Ouro";
            }
            if (produtos >= 5000 && produtos < 10000)
            {
                ViewBag.statusMaster = "Platina";
            }
            if (produtos >= 10000)
            {
                ViewBag.statusMaster = "Diamante";
            }

            return View(clintedest);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteModel clienteModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clintedest = Mapper.Map<ClienteModel, Cliente>(clienteModel);
                    var result = _service.SalvarCliente(clintedest);
                   if (result)
                   {
                       return RedirectToAction("Index");
                   }
                }
                return View(clienteModel);
            }
            catch(Exception e)
            {
                var bb = e;
                return View(clienteModel);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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
