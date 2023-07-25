<%@ LCID=1046 %>

<!--#include file="../includes/api-response.asp"-->
<!--#include file="../includes/jsonObject.class.asp"-->

<%
Dim url, requestData, responseText

Dim name, surname, email, phone
name = Request.Form("name")
surname = Request.Form("surname")
email = Request.Form("email")
phone = Request.Form("phone")

requestData = "{ ""name"": """ & name & """, ""surname"": """ & surname & """, ""email"": """ & email & """, ""phone"": """ & phone & """ }"

url = "https://contact-api.hra.az/api/users/contacts"

Dim http
Set http = Server.CreateObject("WinHTTP.WinHTTPRequest.5.1")
' http.Option(4) = 13056  



http.Open "POST", url, False


Dim jwtToken
jwtToken = Request.Cookies("Token")
If Not IsEmpty(jwtToken) Then
    http.SetRequestHeader "Authorization", "Bearer " & jwtToken
End If

http.SetRequestHeader "Content-Type", "application/json"

http.Send requestData

If http.Status = 200 Then
    Dim jsonResponse
    jsonResponse = http.responseText
   Response.Write jsonResponse

   	set jsonObj = new aspJSON

   
     jsonObj.loadJSON(jsonResponse)
    Dim statusCode
    statusCode = jsonObj.data("statusCode")
    If statusCode = 200 tHEN
        Response.Redirect "https://contact-mvc.hra.az/Contact/List" 
    Else If statusCode = 400 Then
      Response.Redirect "../pages/add-contact.asp"
      End If
    End If
Else
    Response.Write "Error: " & http.Status & " - " & http.StatusText
End If

Set http = Nothing
%>