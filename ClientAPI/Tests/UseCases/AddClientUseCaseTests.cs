using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Enums;
using Moq;
using Domain.DTOs;

namespace Tests.UseCases
{
    public class AddClientUseCaseTests
    {
        [Fact]
        public async Task Execute_ValidClient_CallsClientRepositoryAdd()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new AddClientUseCase(clientRepositoryMock.Object);
            var phone = new AddPhoneNumberDTO("021", "999999999", PhoneType.Mobile);
            var phoneList = new List<AddPhoneNumberDTO> { phone };
            var clientDTO = new AddClientDTO("Bruce Wayne", "notbatman@dc.com", phoneList);
            var client = clientDTO.Transform();

            await useCase.Execute(clientDTO);

            clientRepositoryMock.Verify(r => r.Add(It.IsAny<Client>()), Times.Once);
        }
    }
}