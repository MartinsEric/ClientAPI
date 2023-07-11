using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Enums;
using Moq;
using Domain.DTOs;
using Domain.Exceptions;

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

        [Fact]
        public async Task Execute_CLientAlreadyExists_ThrowAlreadyExistsClientException()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new AddClientUseCase(clientRepositoryMock.Object);
            var phone = new AddPhoneNumberDTO("021", "999999999", PhoneType.Mobile);
            var phoneList = new List<AddPhoneNumberDTO> { phone };
            var clientDTO = new AddClientDTO("Bruce Wayne", "notbatman@dc.com", phoneList);
            var client = clientDTO.Transform();
            var client2 = new Client("Jhon Doe", client.Email);

            clientRepositoryMock.Setup(r => r.GetByEmail(client2.Email)).ReturnsAsync(client2);

            await Assert.ThrowsAsync<AlreadyExistsClientExcption>(() => useCase.Execute(clientDTO));

            clientRepositoryMock.Verify(r => r.Add(It.IsAny<Client>()), Times.Never);
        }
    }
}