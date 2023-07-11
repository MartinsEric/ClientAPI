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
            var clientId = client.Id;

            clientRepositoryMock.Setup(r => r.GetById(clientId)).ReturnsAsync(client);

            await useCase.Execute(clientId);

            clientRepositoryMock.Verify(r => r.Delete(client), Times.Once);
        }

        [Fact]
        public async Task Execute_ClientNotFound_ThrowsClientNotFoundException()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new DeleteClientUseCase(clientRepositoryMock.Object);
            var clientId = Guid.NewGuid();

            clientRepositoryMock.Setup(r => r.GetById(clientId)).ReturnsAsync((Client)null);

            await Assert.ThrowsAsync<ClientNotFoundException>(() => useCase.Execute(clientId));
            clientRepositoryMock.Verify(r => r.Delete(It.IsAny<Client>()), Times.Never);
        }
    }
}
