<%@ LCID=1046 %>

<!-- Include necessary files -->
<!--#include virtual="/myapp/jsonObject.class.asp"-->
<!--#include virtual="/myapp/config.asp"-->

<%
' Critical code section
' If an error occurs, the script will continue after the error handling section
On Error Resume Next
%>

<%
' Retrieve form data submitted by the client
Dim url, requestData, responseText
Dim name, surname, email, phone
name = Request.Form("name")
surname = Request.Form("surname")
email = Request.Form("email")
phone = Request.Form("phone")

' Construct the JSON request data
requestData = "{ ""name"": """ & name & """, ""surname"": """ & surname & """, ""email"": """ & email & """, ""phone"": """ & phone & """ }"

' Set the URL to which the HTTP POST request will be sent
url = API_BASE_URL & "users/contacts"

' Create a WinHTTPRequest object for making the HTTP POST request
Dim http
Set http = Server.CreateObject("WinHTTP.WinHTTPRequest.5.1")
http.Option(4) = 13056   ' Ignore SSL certificate errors (not recommended for production use)

' Open the HTTP request for the specified URL
http.Open "POST", url, False

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
        ' If the status code is 400, redirect to the "../pages/add-contact.asp" page
        Response.Redirect "../pages/add-contact.asp"
    End If
Else
    ' If the HTTP request was not successful, display an error message
    Response.Write "Error: " & http.Status & " - " & http.StatusText
End If

' Clean up and handle any errors
Set http = Nothing
If Err.Number <> 0 Then
    ' If an error occurred during the execution of the script, display error details
    Response.Write  Err.ASPCode
    Response.Write  Err.Number
    Response.Write  Err.Category
    Response.Write  Err.File
    Response.Write  Err.Line
    Response.Write Err.Description
    Response.Write Err.Source
Else
    ' No error occurred, continue with the rest of the script (if any)
End If
%>
