using Application.UseCases;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Moq;

namespace Tests.UseCases
{
    public class DeleteClientUseCaseTests
    {
        [Fact]
        public async Task Execute_ValidData_DeletesClient()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new DeleteClientUseCase(clientRepositoryMock.Object);
            var phone = new AddPhoneNumberDTO("021", "999999999", PhoneType.Mobile);
            var phoneList = new List<AddPhoneNumberDTO> { phone };
            var clientDTO = new AddClientDTO("Bruce Wayne", "notbatman@dc.com", phoneList);
            var client = clientDTO.Transform();

            clientRepositoryMock.Setup(r => r.GetByEmail(client.Email)).ReturnsAsync(client);

            await useCase.Execute(client.Email);

            clientRepositoryMock.Verify(r => r.Delete(client), Times.Once);
        }

        [Fact]
        public async Task Execute_ClientNotFound_ThrowsClientNotFoundException()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new DeleteClientUseCase(clientRepositoryMock.Object);
            var email = "wrongemail@email.com";

            clientRepositoryMock.Setup(r => r.GetByEmail(email)).ReturnsAsync((Client)null);

            await Assert.ThrowsAsync<ClientNotFoundException>(() => useCase.Execute(email));
            clientRepositoryMock.Verify(r => r.Delete(It.IsAny<Client>()), Times.Never);
        }
    }
}
