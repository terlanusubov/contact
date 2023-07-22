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
        USER_IS_ALREADY_EXISTS_WITH_THIS_USERNAME = 1_0_1

    }
}
