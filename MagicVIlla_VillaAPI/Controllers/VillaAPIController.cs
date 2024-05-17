using AutoMapper;
using MagicVIlla_VillaAPI.Models;
using MagicVIlla_VillaAPI.Models.DTOs.VillaDTOs;
using MagicVIlla_VillaAPI.Repository.IRepositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVIlla_VillaAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class VillaAPIController(ILogger<VillaAPIController> logger, IVillaRepository villaRepository, IMapper mapper) : ControllerBase
    {

        private readonly ILogger<VillaAPIController> _logger = logger;
        private readonly IVillaRepository villaRepository = villaRepository;
        private readonly IMapper mapper = mapper;
        protected APIResponse _apiResponse = new ();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all villas data ...");

                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = await villaRepository.GetAllAsync();

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { ex.ToString() };

                return _apiResponse;
            }
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            if(id == 0) 
            {
                _logger.LogError("Villa id is zero !");

                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { "Villa id is zero !" };

                return BadRequest(_apiResponse);
            }

            Villa? villa = await villaRepository.GetAsync(villa => villa.Id == id);

            if(villa == null) 
            {
                _logger.LogError("Cannot find a villa with the id provided !!!!");

                _apiResponse.HttpStatusCode = HttpStatusCode.NotFound;
                _apiResponse.IsSucceess = false;
                _apiResponse.Errors = new List<string> { "Cannot find a villa with the id provided !" };

                return NotFound(_apiResponse);
            }


            try
            {
                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = villa;

                return Ok(_apiResponse);

            }
            catch(Exception ex)
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
        public async Task<ActionResult<APIResponse>> Create(VillaCreationDTO villa) 
        {
            if(villa is null)
            {
                _logger.LogError("Villa is null !");

                _apiResponse.IsSucceess= false;
                _apiResponse.Errors = new List<string> { "Please, porvide valid details for villa !"};
                _apiResponse.HttpStatusCode= HttpStatusCode.BadRequest;

                return BadRequest(_apiResponse);
            }

            try
            {
                Villa villaToCreate = mapper.Map<Villa>(villa);

                villaToCreate.UpdatedDate = DateTime.UtcNow;

                await villaRepository.CreateAsync(villaToCreate);

                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = villaToCreate;

                return CreatedAtRoute("GetVilla", new { id = villaToCreate.Id }, _apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.Errors = new List<string> { ex.ToString() };
                _apiResponse.IsSucceess = false;

                return _apiResponse;
            }

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public async Task<ActionResult<APIResponse>> Delete(int  id)
        {

            if (id == 0)
            {
                _logger.LogError("Id is 0");

                _apiResponse.IsSucceess = false;
                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Errors = new List<string> { "Id is zero !" };

                return BadRequest(_apiResponse);
            }

            Villa? villa = await villaRepository.GetAsync(villa => villa.Id == id);

            if (villa is null)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.HttpStatusCode = HttpStatusCode.NotFound;
                _apiResponse.Errors = new List<string> { "Cannot find villa !" };

                return NotFound(_apiResponse);
            }

            try
            {

                await villaRepository.RemoveAsync(villa);

                _apiResponse.HttpStatusCode = HttpStatusCode.OK;
                _apiResponse.Result = villa;

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
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public async Task<ActionResult<APIResponse>> Update(int id, VillaUpdatDTO villa) 
        {
            if (id == 0 || id != villa.Id)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Errors =  new List<string> { "Invalid Id" };

                return BadRequest(_apiResponse);
            }

            var villaToUpdate = await villaRepository.GetAsync(villa => villa.Id == id);

            if (villaToUpdate is null)
            {
                _apiResponse.IsSucceess = false;
                _apiResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Errors = new List<string> { "Cannot find associated Villa" };

                return BadRequest(_apiResponse);
            }

            try
            {
                villaToUpdate.UpdatedDate = DateTime.UtcNow;
                villaToUpdate.Rate = villa.Rate;
                villaToUpdate.Sqft = villa.Sqft;
                villaToUpdate.Amenity = villa.Amenity;
                villaToUpdate.Details = villa.Details;
                villaToUpdate.Name =  villa.Name;
                villaToUpdate.Occupancy = villa.Occupancy;
                villaToUpdate.ImageUrl = villa.ImageUrl;

                villaToUpdate.UpdatedDate = DateTime.UtcNow;
                await villaRepository.UpdateAsync(villaToUpdate);

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
