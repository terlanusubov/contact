using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.Enums
{
    public enum ErrorCodes
    {

        [Description("Username or password is not correct")]
        USERNAME_OR_PASSWORD_IS_NOT_CORRECT = 1_0_0,

        [Description("There is a user with this username")]
        USER_IS_ALREADY_EXISTS_WITH_THIS_USERNAME = 1_0_1,

        [Description("User is not exists")]
        USER_IS_NOT_EXISTS = 1_0_2,


        [Description("User contact is not exists")]
        USER_CONTACT_IS_NOT_EXISTS = 2_0_0,

        [Description("Contact is already exists with this phone number")]
        USER_CONTACT_IS_ALREADY_EXISTS = 2_0_1,


        [Description("Auth token is empty")]
        AUTH_TOKEN_IS_EMPTY = 3_0_0





    }
}
