using Application.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Moq;

namespace Tests.UseCases
{
    public class GetAllClientsUseCaseTests
    {
        [Fact]
        public async Task Execute_ReturnsListOfClients()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new GetAllClientsUseCase(clientRepositoryMock.Object);
            var expectedClients = new List<Client>
            {
                new Client("Client1", "email1@email.com"),
                new Client ("Client2", "email2@email.com")
            };

            clientRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(expectedClients);

            var result = await useCase.Execute();

            Assert.Equal(expectedClients, result);
        }
    }
}
