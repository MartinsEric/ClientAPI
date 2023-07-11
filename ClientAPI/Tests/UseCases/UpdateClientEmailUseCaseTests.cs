using Application.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Moq;

namespace Tests.UseCases
{
    public class UpdateClientEmailUseCaseTests
    {
        [Fact]
        public async Task Execute_ValidData_UpdatesClientEmail()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new UpdateClientEmailUseCase(clientRepositoryMock.Object);
            var newEmail = "newemail@email.com";
            var client = new Client("Bruce Wayne", "notbatman@dc.com");
            var clientId = client.Id;

            clientRepositoryMock.Setup(r => r.GetById(clientId)).ReturnsAsync(client);

            await useCase.Execute(clientId, newEmail);

            Assert.Equal(newEmail, client.Email);
            clientRepositoryMock.Verify(r => r.Update(client), Times.Once);
        }

        [Fact]
        public async Task Execute_ClientNotFound_ThrowsClientNotFoundException()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new UpdateClientEmailUseCase(clientRepositoryMock.Object);
            var clientId = Guid.NewGuid();
            var newEmail = "newemail@email.com";

            clientRepositoryMock.Setup(r => r.GetById(clientId)).ReturnsAsync((Client)null);

            await Assert.ThrowsAsync<ClientNotFoundException>(() => useCase.Execute(clientId, newEmail));
            clientRepositoryMock.Verify(r => r.Update(It.IsAny<Client>()), Times.Never);
        }
    }
}
