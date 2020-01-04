using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountOwnerServer.Dto;
using AutoMapper;
using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountOwnerServer.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var owners =await _repository.Owner.GetAllOwners();
                _logger.LogInfo($"Returned all owners from database.");
                var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(ownersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/values/5

        [HttpGet("{id}", Name = "OwnerById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerById(id);

                if (owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetWithDetails(Guid id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerWithDetails(id);

                if (owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(_mapper.Map<OwnerDto>(owner));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/values
        [HttpPost]
        [Route("")]
        public IActionResult CreateOwner([FromBody] OwnerForCreationDto owner)
        {
            try
            {
                if (owner == null) 
                {
                    _logger.LogError("Owner object sent from client is null");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Owner object sent from client is Invalid");
                    return BadRequest($"Owner object is Invalid");
                }

                var ownerEntity= _mapper.Map<Owner>(owner);
                _repository.Owner.CreateOwner(ownerEntity);
                var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);
                return CreatedAtRoute("OwnerById", new {id = ownerEntity.Id}, createdOwner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] OwnerForUpdateDto owner)
        {
            try
            {
                if (owner==null)
                {
                    _logger.LogError("Owner object sent from client is null");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Owner object sent from client is Invalid");
                    return BadRequest($"Owner object is Invalid");
                }

                var ownerEntity = await _repository.Owner.GetOwnerById(id);

                if (ownerEntity.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await _repository.Owner.UpdateOwner(ownerEntity);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerById(id);
                if (owner.IsObjectNull())
                {
                    _logger.LogError($"Owner with id {id} not found in database");
                    return NotFound();
                }

                if (_repository.Account.AccountsByOwner(id).GetAwaiter().GetResult().Any())
                {
                    _logger.LogError(
                        $"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }

                await _repository.Owner.DeleteOwner(owner);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}