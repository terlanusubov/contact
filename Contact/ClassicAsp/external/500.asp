<%
Option Explicit

Dim objASPError
Set objASPError = Server.GetLastError()

Response.Clear
Response.Status = "500 Internal Server Error"

'
Dim errorMessage
errorMessage = "An unexpected error occurred on the server. Please try again later."

%>
<!DOCTYPE html>
<html>
<head>
    <title>Error 500 - Internal Server Error</title>
</head>
<body>
    <h1>Error 500 - Internal Server Error</h1>
    <p><%= errorMessage %></p>
    <p><strong>Error Details:</strong></p>
    <p><b>ASPCode:</b> <%= objASPError.ASPCode %></p>
    <p><b>Number:</b> <%= objASPError.Number %></p>
    <p><b>Category:</b> <%= objASPError.Category %></p>
    <p><b>File:</b> <%= objASPError.File %></p>
    <p><b>Line:</b> <%= objASPError.Line %></p>
    <p><b>Description:</b> <%= objASPError.Description %></p>
    <p><b>Source:</b> <%= objASPError.Source %></p>
</body>
</html>
