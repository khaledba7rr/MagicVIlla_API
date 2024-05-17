using AutoMapper;
using MagicVIlla_VillaAPI.Models;
using MagicVIlla_VillaAPI.Models.DTOs.VillaDTOs;
using MagicVIlla_VillaAPI.Models.DTOs.VillaNumberDTOs;
using MagicVIlla_VillaAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVIlla_VillaAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class VillaNoController(ILogger<VillaNoController> logger, IMapper mapper, IVillaNoRepository villaNoRepository) : Controller
    {
        private readonly ILogger<VillaNoController> _logger = logger;
        private readonly IMapper mapper = mapper;
        private readonly IVillaNoRepository villaNoRepository = villaNoRepository;
        protected APIResponse _apiResponse = new();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        public async Task<ActionResult<APIResponse>> VillasNumbers()
        {
            try
            {
                _logger.LogInformation("Getting all villas numbers data ...");

                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = await villaNoRepository.GetAllAsync();

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { ex.ToString() };

                return _apiResponse;
            }
        }

        [HttpGet("{villaNo:int}", Name = "GetVillaNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> VillaNumber(int villaNo)
        {
            if (villaNo == 0)
            {
                _logger.LogError("Villa No id is zero !");

                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { "Villa number is zero !" };

                return BadRequest(_apiResponse);
            }

            VillaNumber? villaNumber = await villaNoRepository.GetAsync(villa => villa.VillaNo == villaNo);

            if (villaNumber == null)
            {
                _logger.LogError("Cannot find a villa number with the number provided !!!!");

                _apiResponse.HttpStatusCode = HttpStatusCode.NotFound;
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { "Cannot find a villa number with the number provided !" };

                return NotFound(_apiResponse);
            }


            try
            {
                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = villaNumber;

                return Ok(_apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { ex.ToString() };

                return _apiResponse;
            }

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create(VillaNumberCreateDTO villaNumber)
        {
            if (villaNumber is null)
            {
                _logger.LogError("Villa Number is null !");

                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { "Please, porvide valid details for villa number !" };
                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;

                return BadRequest(_apiResponse);
            }

            try
            {
                VillaNumber villaToCreate = mapper.Map<VillaNumber>(villaNumber);

                villaToCreate.CreationDate = DateTime.UtcNow;

                await villaNoRepository.CreateAsync(villaToCreate);

                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = villaToCreate;

                return CreatedAtRoute("GetVillaNo", new { villaNo = villaToCreate.VillaNo }, _apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Errors = new List<string> { ex.ToString() };
                _apiResponse.IsSucceess = false;

                return _apiResponse;
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{villaNo:int}", Name = "DeleteVillaNumber")]
        public async Task<ActionResult<APIResponse>> Delete(int villaNo)
        {

            if (villaNo == 0)
            {
                _logger.LogError("villa number is 0");

                _apiResponse.IsSucceess = false;
                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Errors = new List<string> { "Villa number is zero !" };

                return BadRequest(_apiResponse);
            }

            VillaNumber? villaNumber = await villaNoRepository.GetAsync(villa => villa.VillaNo == villaNo);

            if (villaNumber is null)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.HttpStatusCode = HttpStatusCode.NotFound;
                _apiResponse.Errors = new List<string> { "Cannot find villa number !" };

                return NotFound(_apiResponse);
            }

            try
            {

                await villaNoRepository.RemoveAsync(villaNumber);

                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = villaNumber;

                return Ok(_apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { ex.ToString() };

                return _apiResponse;
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{villaNo:int}", Name = "UpdateVillaNumber")]
        public async Task<ActionResult<APIResponse>> Update(int villaNo, VillaNumberUpdateDTO villa)
        {
            if (villaNo == 0 || villaNo != villa.VillaNo)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Errors = new List<string> { "Invalid Villa number" };

                return BadRequest(_apiResponse);
            }

            var villaToUpdate = await villaNoRepository.GetAsync(villa => villa.VillaNo == villaNo);

            if (villaToUpdate is null)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Errors = new List<string> { "Cannot find associated Villa" };

                return BadRequest(_apiResponse);
            }

            try
            {
                villaToUpdate = mapper.Map<VillaNumber>(villa);

                await villaNoRepository.UpdateAsync(villaToUpdate);

                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = villaToUpdate;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { ex.ToString() };

                return _apiResponse;
            }


        }

    }
}
