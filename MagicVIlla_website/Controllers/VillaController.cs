using AutoMapper;
using MagicVIlla_website.Models;
using MagicVIlla_website.Models.DTOs.VillaDTOs;
using MagicVIlla_website.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVIlla_website.Controllers
{
    public class VillaController(IVillaService villaService, IMapper mapper) : Controller
    {
        private readonly IVillaService villaService = villaService;
        private readonly IMapper mapper = mapper;

        public async Task<IActionResult> VillaIndex()
        {
            List<VillaDTO> villas = new List<VillaDTO>();

            var response = await villaService.GetAllVillas<APIResponse>();

            if (response != null && response.IsSucceess)
            {
                villas = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }

            return View(villas);
        }

        [HttpGet]
        public IActionResult CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreationDTO model)
        {
            if (ModelState.IsValid)
            {
                await villaService.CreateVilla<APIResponse>(model);

                return RedirectToAction("VillaIndex");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVilla(int id)
        {
            var response = await villaService.GetVilla<APIResponse>(id);

            if (response is not null && response.IsSucceess)
            {
                var villa = JsonConvert.DeserializeObject<VillaUpdatDTO>(Convert.ToString(response.Result));

                return View(villa);
            }

            return RedirectToAction("VillaIndex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdatDTO villa)
        {
            if (ModelState.IsValid)
            {
                await villaService.UpdateVilla<APIResponse>(villa);

                return RedirectToAction("VillaIndex");

            }

            return View(villa);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var respone = await villaService.GetVilla<APIResponse>(id);

            if (respone is not null && respone.IsSucceess)
            {
                var villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(respone.Result));

                return View(villa);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO villa) 
        {

           var response =  await villaService.DeleteVilla<APIResponse>(villa.Id);

            if(response is not null && response.IsSucceess)
            {

                return RedirectToAction(nameof(VillaIndex));

            }

            return View(villa); 
        }

    }
}
