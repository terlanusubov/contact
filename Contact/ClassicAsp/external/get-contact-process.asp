<!--#include virtual="/myapp/jsonObject.class.asp"-->

<%

' Get the contactId from the query string
Dim contactId
contactId = Request.QueryString("contactId")
Response.Write contactId
' Check if contactId is present and has a valid value
If Len(contactId) > 0 And IsNumeric(contactId) Then
    ' Perform any necessary actions with the contactId
    ' For example, you might use it in the API URL to fetch contact data
    Dim apiUrl
    apiUrl = API_BASE_URL & "users/contacts/" & contactId

    Dim  jsonResponse, data


            ' Check if contactId is present and has a valid value
            If Len(contactId) > 0 And IsNumeric(contactId) Then
                ' Create the XMLHTTP object
                Dim http
                Set http = Server.CreateObject("WinHTTP.WinHTTPRequest.5.1")
                http.Option(4) = 13056  ' WinHttpRequestOption_SslErrorIgnoreFlags

                ' Make the API call
                http.Open "GET", apiUrl, False

                Dim jwtToken
                 jwtToken = Request.Cookies("Token")
                If Not IsEmpty(jwtToken) Then
                http.SetRequestHeader "Authorization", "Bearer " & jwtToken
                End If

                http.Send

                ' Check if the API call was successful
                If http.Status = 200 Then
                    ' Parse the JSON response
                    jsonResponse = http.responseText
                    
                Else
                   Response.Write http.Status
                End If

                Set xmlhttp = Nothing
            Else
                ' Handle the case when contactId is missing or not a valid value
                ' For example, display an error message or redirect to an error page
                MsgBox "Invalid or missing contactId."
            End If

Else
    ' Handle the case when contactId is missing or not a valid value
    ' For example, display an error message or redirect to an error page
    Response.Write "Invalid or missing contactId."
End If
%>