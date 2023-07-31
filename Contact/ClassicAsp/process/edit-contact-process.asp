<%@ LCID=1046 %>

<!-- Include necessary files -->
<!--#include virtual="/myapp/jsonObject.class.asp"-->
<!--#include virtual="/myapp/config.asp"-->


<%
' Retrieve data from the form and query string
Dim url, requestData, responseText
Dim name, surname, email, phone, contactId
name = Request.Form("name")
contactId = Request.QueryString("contactId")
surname = Request.Form("surname")
email = Request.Form("email")
phone = Request.Form("phone")

' Construct the JSON request data with the updated contact information
requestData = "{ ""name"": """ & name & """, ""suraname"": """ & surname & """, ""email"": """ & email & """, ""phone"": """ & phone & """ }"

' Set the URL for the HTTP POST request to update the contact
url = API_BASE_URL & "users/contacts/" & contactId & "/update"

' Output the URL for debugging purposes (optional)
Response.Write url

' Create a WinHTTPRequest object for making the HTTP POST request
Dim http
Set http = Server.CreateObject("WinHTTP.WinHTTPRequest.5.1")
http.Option(4) = 13056   ' Ignore SSL certificate errors (not recommended for production use)

' Open the HTTP request for the specified URL
http.Open "POST", url, False

' Output the JSON request data for debugging purposes (optional)
Response.Write requestData

' Get the JWT token from the "Token" cookie and set it as the Authorization header (if available)
Dim jwtToken
jwtToken = Request.Cookies("Token")
If Not IsEmpty(jwtToken) Then
    http.SetRequestHeader "Authorization", "Bearer " & jwtToken
End If

' Set the request content type to JSON
http.SetRequestHeader "Content-Type", "application/json"

' Send the HTTP POST request with the JSON data
http.Send requestData

' Check the HTTP response status
If http.Status = 200 Then
    ' If the request was successful (status code 200)
    Dim jsonResponse
    jsonResponse = http.responseText
    Response.Write jsonResponse

    ' Parse the JSON response
    Set jsonObj = New aspJSON
    jsonObj.loadJSON(jsonResponse)

    ' Extract the status code from the JSON response
    Dim statusCode
    statusCode = jsonObj.data("statusCode")

    ' Redirect based on the status code
    If statusCode = 200 Then
        ' If the status code is 200, redirect to the "Contact/List" page
        Response.Redirect MVC_BASE_URL & "Contact/List"
    ElseIf statusCode = 400 Then
        ' If the status code is 400, redirect to the "../pages/edit-contact.asp?contactId=" page with the specified contactId
        Response.Redirect "../pages/edit-contact.asp?contactId=" & contactId
    End If
Else
    ' If the HTTP request was not successful, display an error message
    Response.Write "Error: " & http.Status & " - " & http.StatusText
End If

' Clean up
Set http = Nothing
%>
