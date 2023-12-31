﻿using Application.UseCases;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Moq;

namespace Tests.UseCases
{
    public class UpdateClientPhoneUseCaseTests
    {
        [Fact]
        public async Task Execute_ValidData_UpdatesClientPhone()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var phoneNumberRepositoryMock = new Mock<IPhoneNumberRepository>();
            var useCase = new UpdateClientPhoneUseCase(clientRepositoryMock.Object, phoneNumberRepositoryMock.Object);
            var phoneNumber = new PhoneNumber("021", "999999999", PhoneType.Mobile);
            var newPhoneNumber = new PhoneNumber("021", "988888888", PhoneType.Mobile);
            var client = new Client("Bruce Wayne", "notbatman@dc.com");
            client.AddPhoneNumber(phoneNumber);
            var clientId = client.Id;
            
            clientRepositoryMock.Setup(r => r.GetByEmail(client.Email)).ReturnsAsync(client);

            await useCase.Execute(client.Email, phoneNumber.ToString(), newPhoneNumber);

            var updatedPhone = client.Phones.FirstOrDefault(p => p.ToString() == phoneNumber.ToString());
            Assert.NotNull(updatedPhone);
            Assert.Equal(newPhoneNumber.DDD, updatedPhone.DDD);
            Assert.Equal(newPhoneNumber.Number, updatedPhone.Number);
            Assert.Equal(newPhoneNumber.Type, updatedPhone.Type);
            phoneNumberRepositoryMock.Verify(r => r.Update(updatedPhone), Times.Once);
        }

        [Fact]
        public async Task Execute_ClientNotFound_ThrowsClientNotFoundException()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var phoneNumberRepositoryMock = new Mock<IPhoneNumberRepository>();
            var useCase = new UpdateClientPhoneUseCase(clientRepositoryMock.Object, phoneNumberRepositoryMock.Object);
            var email = "wrongemail@email.com";
            var phoneNumber = "021999999999";
            var newPhoneNumber = new PhoneNumber("021", "988888888", PhoneType.Mobile);

            clientRepositoryMock.Setup(r => r.GetByEmail(email)).ReturnsAsync((Client)null);

            await Assert.ThrowsAsync<ClientNotFoundException>(() => useCase.Execute(email, phoneNumber, newPhoneNumber));
            phoneNumberRepositoryMock.Verify(r => r.Update(It.IsAny<PhoneNumber>()), Times.Never);
        }

        [Fact]
        public async Task Execute_PhoneNotFound_ThrowsPhoneNotFoundException()
        {
            var clientRepositoryMock = new Mock<IClientRepository>();
            var phoneNumberRepositoryMock = new Mock<IPhoneNumberRepository>();
            var useCase = new UpdateClientPhoneUseCase(clientRepositoryMock.Object, phoneNumberRepositoryMock.Object);
            var clientId = Guid.NewGuid();
            var phoneNumber = new PhoneNumber("021", "999999999", PhoneType.Mobile);
            var newPhoneNumber = new PhoneNumber("021", "988888888", PhoneType.Mobile);
            var wrongPhoneNumber = "021123456789";
            var phoneList = new List<PhoneNumber> { phoneNumber };
            var client = new Client("Bruce Wayne", "notbatman@dc.com");
            client.AddPhoneNumber(phoneNumber);

            clientRepositoryMock.Setup(r => r.GetByEmail(client.Email)).ReturnsAsync(client);

            await Assert.ThrowsAsync<PhoneNotFoundException>(() => useCase.Execute(client.Email, wrongPhoneNumber, newPhoneNumber));
            phoneNumberRepositoryMock.Verify(r => r.Update(It.IsAny<PhoneNumber>()), Times.Never);
        }
    }
}
