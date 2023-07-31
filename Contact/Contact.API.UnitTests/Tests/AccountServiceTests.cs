using System;
using Contact.API.UnitTests.Helper;
using Contact.Application.Interfaces;
using Contact.Application.Models.Request;

namespace Contact.API.UnitTests.Tests
{
    public class AccountServiceTests : BaseTest
    {

        [Fact]
        public async Task RegisterUserWithCorrectCredentials_ReturnUserId()
        {
            var model = new RegisterRequest();

            model.Name = "Tural";
            model.Surname = "Usubov";
            model.Email = "tural.usubov@gmail.com";
            model.Password = "Tural123@";
            model.Username = "turalusubov";

            var response = await _accountService.Register(model);

            Assert.NotNull(response.Response);
        }

        [Fact]
        public async Task IFUsernameExistsThen_ReturnError()
        {
            var model = new RegisterRequest();

            model.Name = "Tarlan";
            model.Surname = "Usubov";
            model.Email = "tarlan.usubov@gmail.com";
            model.Password = "Terlan123@";
            model.Username = "terlanusubov";

            var response = await _accountService.Register(model);

            Assert.Equal(101, response.ErrorCode);
        }

    }
}

