using FormClean.Application.DTOs;
using FormClean.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FormClean.WebUI.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IDemandedService _demandedService;

        public ClientsController(IClientService clientService, IDemandedService demandedService)
        {
            _clientService = clientService;
            _demandedService = demandedService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAllClients();
            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDTO clientDto)
        {
            if (ModelState.IsValid)
            {
                await _clientService.Create(clientDto);
                return RedirectToAction("Create","Demandeds");
            }
            return View(clientDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var clientDto = await _clientService.GetClientById(id);
            if (clientDto == null) return NotFound();
            return View(clientDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientDTO clientDto)
        {
            if (ModelState.IsValid)
            {
                await _clientService.Update(clientDto);
                return RedirectToAction("Index");
            }
            return View(clientDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var clientDto = await _clientService.GetClientById(id);
            if (clientDto == null) return NotFound();
            return View(clientDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var clientDto = await _clientService.GetClientById(id);
            if (clientDto == null) return NotFound();
            return View(clientDto);
        }
    }
}
