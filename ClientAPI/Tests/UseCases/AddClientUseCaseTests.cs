using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Enums;
using Moq;

namespace Tests.UseCases
{
    public class AddClientUseCaseTests
    {
        [Fact]
        public async Task Execute_ValidClient_CallsClientRepositoryAdd()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new AddClientUseCase(clientRepositoryMock.Object);
            var phone = new PhoneNumber("021", "999999999", PhoneType.Mobile);
            var phoneList = new List<PhoneNumber> { phone };
            var client = new Client("Bruce Wayne", "notbatman@dc.com", phoneList);

            await useCase.Execute(client);

            clientRepositoryMock.Verify(r => r.Add(client), Times.Once);
        }
    }
}