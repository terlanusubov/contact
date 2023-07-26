<!--#include file="config.asp"-->
<%
Dim token
token = Request.Cookies("Token")

' Check if the "Token" cookie exists
If token = "" Or IsEmpty(token) Then
    Response.Redirect MVC_BASE_URL & "Account/Login"
Else

End If
%>