# Contact API 



Welcome to the Contact API documentation! 
## Table of Contents

- [Technical Info]
- [Authentication]
- [Contact.API]
- [Contact.MVC]
- [Classic.ASP]
- [Deployment]
- [Error Codes]


<p align="center">
  <img src="https://test-contact-api.azurewebsites.net/diagram.png" alt="Alt Text">
</p>



## Technical Info

This API designed with Clean Architecture , we have multiple layers such as :
- [Domain]
- [Application]
- [Infrastructure]
- [Presentation]

Presentation consist of 2 applications , one of them is Contact.API and another one is Contact.MVC

We have also Classic ASP app which hosted codes in ClassicASP folder.

Contact.API is communcation bridge for Contact.MVC and ClassicASP

In my API architecture I have used Service based logic which means each Entity has service in order to use them functionalities.

- [IUserService]
- [IAccountService]
- [IUserContactService]

and some other services for Application Logic

I have generic ApiResult<TResponse> class in order to make same API response pattern in all services.

ApiResult consists of 2 main function OK and Error

- [Response]
- [StatusCode]
- [ErrorCode]
- [Description]

## Authentication

I have used JWT bearer Authentication . Each apiuser must get token from API in order to use some endpoints
When apiuser login the API , then api send token also in cookie.



## Contact.API

- [/api/account/login - POST]
- [/api/account/register -POST]
- [/api/users/contacts - GET]
- [/api/users/contacts - POST]
- [/api/users/contacts/{contactId} -GET]
- [/api/users/contacts/{contactId} - PUT]

Custom [Auth] Authorization filter attribute checks the JWT token validity

## Contact.MVC
Contact MVC consume data from Contact.API . As Authorization Contact.MVC sends token from header which key is Authorization.
- [Account/Login]
- [Account/Register]
- [Contact/List]
- [Contact/Delete]
  
## Classic.ASP

 Classic ASP part is very simple. There are some functionalites there which are edit and create contact. I have used VB and JS script (most of VBSscript).
 - [add-contact.asp]
 - [edit-contact.asp]
## Sharing Session

API has JWT authentication. When User tries to login to the system , API response to user via cookie . I host jwt token in cookie with SameSiteMode NONE and same domain path with other projects (Classic asp and ASP.NET Core MVC). That's why Classic asp can get token from cookie and we can store our claims in JWT token. Classic asp can parse and get all claims which it need.

## Delpoyment

Azure App services with Github Actions implementation. 
Main branch listen to API (has yml file for API)
MVC branch listen to MVC (has yml file for MVC)
Classic asp hosted in Azure app services also, but deployed with FTP.

## Error Codes

 USERNAME_OR_PASSWORD_IS_NOT_CORRECT = 1_0_0,

 USER_IS_ALREADY_EXISTS_WITH_THIS_USERNAME = 1_0_1,

 USER_IS_NOT_EXISTS = 1_0_2,


 USER_CONTACT_IS_NOT_EXISTS = 2_0_0,

 USER_CONTACT_IS_ALREADY_EXISTS = 2_0_1,


 AUTH_TOKEN_IS_EMPTY = 3_0_0
