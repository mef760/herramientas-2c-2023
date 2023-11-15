using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clase13.Data;
using clase13.Models;
using clase13.ViewModels;
using clase13.Services;
using Microsoft.AspNetCore.Authorization;

namespace clase13.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAll(string.Empty);
            if (clients is null)
            {
                Problem("Entity set 'Clase13Context.Client'  is null.");
            }
            var clientsVM = new ClientListVM {
                Clients = clients
                    .Select(x => new ClientVM { Id = x.Id, Name = x.Name, Email = x.Email}).ToList()
            };
            return View(clientsVM);                         
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var client = await _clientService.GetById(id);
            if (id == null || client == null)
            {
                return NotFound();
            }
            var clientVM = new ClientVM {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email
            };

            return View(clientVM);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email")] ClientVM client)
        {
            if (ModelState.IsValid)
            {
                var newClient = new Client {
                    Name = client.Name,
                    Email = client.Email
                };
                await _clientService.Create(newClient);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var client = await _clientService.GetById(id);
            if (id == null || client == null)
            {
                return NotFound();
            }

            var clientVM = new ClientVM {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email
            };

            return View(clientVM);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] ClientVM client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedClient = new Client {
                        Id = client.Id,
                        Name = client.Name,
                        Email = client.Email
                    };
                    await _clientService.Update(updatedClient);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var client = await _clientService.GetById(id);
            if (id == null || client == null)
            {
                return NotFound();
            }
            var clientVM = new ClientVM {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email
            };

            return View(clientVM);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id != 0)
            {
                await _clientService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
