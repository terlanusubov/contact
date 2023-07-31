using Contact.API.UnitTests.Helper;
using Contact.Application.Interfaces;
using Contact.Application.Models.Request;
using Contact.Domain.Entities;

namespace Contact.API.UnitTests.Tests;


public class UserContactServiceTests : BaseTest
{

    [Fact]
    public async Task AddUserContactWithCorrectCredentials_ReturnUserContactId()
    {
        var userContact = new CreateUserContactRequest();
        userContact.Email = "eyyub@gmail.com";
        userContact.Name = "Eyyub";
        userContact.Surname = "Qafarov";
        userContact.Phone = "0503401499";


        var response = await _userContactService.CreateUserContact(userContact, UserId);

        UserContactId = response.Response.ContactId;

        Assert.NotNull(response.Response);
    }

    [Fact]
    public async Task EditUserContactWithCorrectCredentials_ReturnUserContactId()
    {
        var userContact = new UpdateUserContactRequest();
        userContact.Email = "eyyubChanged@gmail.com";
        userContact.Name = "EyyubChanged";
        userContact.Suraname = "QafarovChanged";
        userContact.Phone = "0503401499";

        var response = await _userContactService.UpdateUserContact(userContact, UserContactId, UserId);

        Assert.NotNull(response.Response);

    }

}
