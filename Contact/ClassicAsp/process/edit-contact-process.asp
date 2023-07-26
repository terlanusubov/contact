<%@ LCID=1046 %>

<!--#include virtual="/myapp/jsonObject.class.asp"-->
<!--#include virtual="/myapp/config.asp"-->


<%
Dim url, requestData, responseText

Dim name, surname, email, phone,contactId
name = Request.Form("name")
contactId = Request.QueryString("contactId")
surname = Request.Form("surname")
email = Request.Form("email")
phone = Request.Form("phone")

requestData = "{ ""name"": """ & name & """, ""suraname"": """ & surname & """, ""email"": """ & email & """, ""phone"": """ & phone & """ }"

url = API_BASE_URL & "users/contacts/" & contactId & "/update"
Response.Write url
Dim http
Set http = Server.CreateObject("WinHTTP.WinHTTPRequest.5.1")
 http.Option(4) = 13056  

http.Open "POST", url, False
Response.Write requestData

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
        Response.Redirect MVC_BASE_URL & "Contact/List" 
    Else If statusCode = 400 Then
      Response.Redirect "../pages/edit-contact.asp?contactId=" & contactId
      End If
    End If
Else
    Response.Write "Error: " & http.Status & " - " & http.StatusText
End If



Set http = Nothing
%>