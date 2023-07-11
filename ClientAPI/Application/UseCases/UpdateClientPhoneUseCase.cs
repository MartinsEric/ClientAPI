using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

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

        public async Task Execute(string email, string phoneNumber, PhoneNumber newPhoneNumber)
        {
            var client = await _clientRepository.GetByEmail(email) ?? throw new ClientNotFoundException(email);
            var phone = client.Phones.FirstOrDefault(phone => phone.ToString() == phoneNumber) ?? throw new PhoneNotFoundException(phoneNumber);

            phone.UpdatePhoneNumber(newPhoneNumber);
            await _phoneNumberRepository.Update(phone);
        }
    }
}
