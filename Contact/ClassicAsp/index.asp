<%

' Declare a variable "token" to store the value of the "Token" cookie
Dim token
token = Request.Cookies("Token")

' Check if the "Token" cookie exists and has a value
If token = "" Or IsEmpty(token) Then
    ' If the cookie does not exist or has no value, redirect the user to the login page
    Response.Redirect "https://contact-mvc.hra.az/Account/Login"
Else
    ' If the "Token" cookie exists and has a value, redirect the user to the "add-contact.asp" page
    Response.Redirect "pages/add-contact.asp"
End If
%>