using FormClean.Application.DTOs;
using FormClean.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FormClean.WebUI.Controllers
{
    public class DemandedsController : Controller
    {
        private readonly IDemandedService _demandedService;
        private readonly IClientService _clientService;

        public DemandedsController(IDemandedService demandedService, IClientService clientService)
        {
            _demandedService = demandedService;
            _clientService = clientService;

            _clientService.GetAllClients().Result.GetEnumerator();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var demanded = await _demandedService.GetAllDemandeds();
            return View(demanded);
        }

        [HttpGet]
        public IActionResult VerifyClientExists() 
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ClientId = new SelectList(await _clientService.GetAllClients(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DemandedDTO demandedDto)
        {
            if (ModelState.IsValid)
            {
                await _demandedService.Create(demandedDto);
                return RedirectToAction("Index");
            }
            return View(demandedDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.ClientId = new SelectList(await _clientService.GetAllClients(), "Id", "Name");
            if (id == null) return NotFound();

            var demandedDto = await _demandedService.GetDemandedsById(id);

            if (demandedDto == null) return NotFound();
            return View(demandedDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DemandedDTO demandedDto)
        {
            if (ModelState.IsValid)
            {
                await _demandedService.Update(demandedDto);
                return RedirectToAction("Index");
            }
            return View(demandedDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var demandedDto = await _demandedService.GetDemandedsById(id);
            if (demandedDto == null) return NotFound();
            return View(demandedDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _demandedService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var demandedDto = await _demandedService.GetDemandedsById(id);
            if (demandedDto == null) return NotFound();
            return View(demandedDto);
        }
    }
}
