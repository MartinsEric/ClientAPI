using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UpdateClientPhoneUseCase : UseCaseBase, IUpdateClientPhoneUseCase
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        public UpdateClientPhoneUseCase(IClientRepository clientRepository, IPhoneNumberRepository phoneNumberRepository) 
            : base(clientRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        public async Task Execute(Guid clientId, string phoneNumber, PhoneNumber newPhoneNumber)
        {
            var client = await _clientRepository.GetById(clientId) ?? throw new ClientNotFoundException(clientId);
            var phone = client.Phones.FirstOrDefault(phone => phone.ToString() == phoneNumber) ?? throw new PhoneNotFoundException(phoneNumber);

            phone.UpdatePhoneNumber(newPhoneNumber);
            await _phoneNumberRepository.Update(phone);
        }
    }
}
