<%


Dim token
token = Request.Cookies("Token")

' Check if the "Token" cookie exists
If token = "" Or IsEmpty(token) Then
    
    Response.Redirect "https://contact-mvc.hra.az/Account/Login"
Else
    Response.Redirect "pages/add-contact.asp"
End If
%>