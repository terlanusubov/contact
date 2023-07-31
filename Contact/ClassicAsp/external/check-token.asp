<!-- Include the "config.asp" file -->
<!--#include file="config.asp"-->

<%
' Retrieve the "Token" cookie from the request
Dim token
token = Request.Cookies("Token")

' Check if the "Token" cookie exists and has a value
If token = "" Or IsEmpty(token) Then
    ' If the "Token" cookie does not exist or has no value, redirect to the login page
    Response.Redirect MVC_BASE_URL & "Account/Login"
Else
    ' If the "Token" cookie exists and has a value, continue with the rest of the code (if any)
    ' (Note: Currently, the code block does not have any further instructions after this condition.)
End If
%>
