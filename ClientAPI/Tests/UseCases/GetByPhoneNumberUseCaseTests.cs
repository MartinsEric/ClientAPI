using Application.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Moq;

namespace Tests.UseCases
{
    public class GetByPhoneNumberUseCaseTests
    {
        [Fact]
        public async Task Execute_ValidPhoneNumber_ReturnsClient()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var useCase = new GetByPhoneNumberUseCase(clientRepositoryMock.Object);
            var phone1 = new PhoneNumber("021", "999999999", PhoneType.Mobile);
            var phone2 = new PhoneNumber("021", "988888888", PhoneType.Mobile);
            var phoneList = new List<PhoneNumber> { phone1, phone2 };
            var expectedClient = new Client("Bruce Wayne", "notbatman@dc.com", phoneList);
            clientRepositoryMock.Setup(r => r.GetByPhoneNumber(phone1.ToString())).ReturnsAsync(expectedClient);

            var result = await useCase.Execute(phone1.ToString());

            Assert.Equal(expectedClient, result);
            Assert.Contains(result.Phones, p => p.ToString() == phone1.ToString());
        }
    }
}
