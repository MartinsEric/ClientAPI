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

            clientRepositoryMock.Setup(r => r.GetByEmail(client.Email)).ReturnsAsync(client);

            await useCase.Execute(client.Email, newEmail);

            Assert.Equal(newEmail, client.Email);
            clientRepositoryMock.Verify(r => r.Update(client), Times.Once);
        }

        [Fact]
        public async Task Execute_ClientNotFound_ThrowsClientNotFoundException()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new UpdateClientEmailUseCase(clientRepositoryMock.Object);
            var email = "wrongemail@test.com";
            var newEmail = "newemail@email.com";

            clientRepositoryMock.Setup(r => r.GetByEmail(email)).ReturnsAsync((Client)null);

            await Assert.ThrowsAsync<ClientNotFoundException>(() => useCase.Execute(email, newEmail));
            clientRepositoryMock.Verify(r => r.Update(It.IsAny<Client>()), Times.Never);
        }
    }
}
