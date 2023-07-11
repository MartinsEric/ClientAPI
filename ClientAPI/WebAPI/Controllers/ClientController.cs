using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IGetAllClientsUseCase _getAllClientsUseCase;
        private readonly IGetByPhoneNumberUseCase _getByPhoneNumberUseCase;
        private readonly IAddClientUseCase _addClientUseCase;
        private readonly IUpdateClientEmailUseCase _updateClientEmailUseCase;
        private readonly IUpdateClientPhoneUseCase _updateClientPhoneUseCase;
        private readonly IDeleteClientUseCase _deleteClientUseCase;

        public ClientController(
            IGetAllClientsUseCase getAllClientsUseCase,
            IGetByPhoneNumberUseCase getByPhoneNumberUseCase,
            IAddClientUseCase addClientUseCase,
            IUpdateClientEmailUseCase updateClientEmailUseCase,
            IUpdateClientPhoneUseCase updateClientPhoneUseCase,
            IDeleteClientUseCase deleteClientUseCase)
        {
            _getAllClientsUseCase = getAllClientsUseCase;
            _getByPhoneNumberUseCase = getByPhoneNumberUseCase;
            _addClientUseCase = addClientUseCase;
            _updateClientEmailUseCase = updateClientEmailUseCase;
            _updateClientPhoneUseCase = updateClientPhoneUseCase;
            _deleteClientUseCase = deleteClientUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _getAllClientsUseCase.Execute();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] AddClientDTO clientDTO)
        {
            try
            {
                await _addClientUseCase.Execute(clientDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetClientByPhoneNumber(string phoneNumber)
        {
            var client = await _getByPhoneNumberUseCase.Execute(phoneNumber);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPut("{clientId}/email")]
        public async Task<IActionResult> UpdateClientEmail(Guid clientId, [FromBody] string newEmail)
        {
            try
            {
                await _updateClientEmailUseCase.Execute(clientId, newEmail);
                return NoContent();
            }
            catch (ClientNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{clientId}/phone/{phoneNumber}")]
        public async Task<IActionResult> UpdateClientPhone(Guid clientId, string phoneNumber, [FromBody] PhoneNumber newPhoneNumber)
        {
            try
            {
                await _updateClientPhoneUseCase.Execute(clientId, phoneNumber, newPhoneNumber);
                return NoContent();
            }
            catch (ClientNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (PhoneNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            try
            {
                await _deleteClientUseCase.Execute(clientId);
                return NoContent();
            }
            catch (ClientNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
