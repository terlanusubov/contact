<%@ LCID=1046 %>
<!--#include virtual="/myapp/check-token.asp"-->

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Contact.MVC</title>
    <link rel="stylesheet" href="../lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/site.css"  />
    <style>
  
a.navbar-brand[b-t51quky6kd] {
  white-space: normal;
  text-align: center;
  word-break: break-all;
}

a[b-t51quky6kd] {
  color: #0077cc;
}

.btn-primary[b-t51quky6kd] {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.nav-pills .nav-link.active[b-t51quky6kd], .nav-pills .show > .nav-link[b-t51quky6kd] {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.border-top[b-t51quky6kd] {
  border-top: 1px solid #e5e5e5;
}
.border-bottom[b-t51quky6kd] {
  border-bottom: 1px solid #e5e5e5;
}

.box-shadow[b-t51quky6kd] {
  box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
}

button.accept-policy[b-t51quky6kd] {
  font-size: 1rem;
  line-height: inherit;
}

.footer[b-t51quky6kd] {
  position: absolute;
  bottom: 0;
  width: 100%;
  white-space: nowrap;
  line-height: 60px;
}

    </style>
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container-fluid">
                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
<%
' Check if the "token" cookie exists
If Request.Cookies("Token") = "" Then
%>
    <li class="nav-item">
                                <a class="nav-link text-dark" href="https://contact-mvc.hra.az/account/login">Login</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link text-dark" href="https://contact-mvc.hra.az/account/register">Register</a>
                            </li>
<%
Else
%>
     <li class="nav-item">
                                <a class="nav-link text-dark" href="https://contact-mvc.hra.az/contact/list">Contacts</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link text-dark" href="https://contact-mvc.hra.az/account/logout">Logout</a>
                            </li>
<%
End If
%>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
    

   
<div class="">
   <div class="container mt-5">
        <h1>Enter Your Details</h1>
        <form action="/process/edit-contact-process.asp" method="post">
            <div class="form-group">
                <label for="name">Name:</label>
                <input type="text" class="form-control" id="name" name="name" required>
            </div>
            <div class="form-group">
                <label for="surname">Surname:</label>
                <input type="text" class="form-control" id="surname" name="surname" required>
            </div>
            <div class="form-group">
                <label for="email">Email:</label>
                <input type="email" class="form-control" id="email" name="email" required>
            </div>
            <div class="form-group">
                <label for="phone">Phone:</label>
                <input type="text" class="form-control" id="phone" name="phone" required>
            </div>
            <button type="submit" class="btn btn-primary">Edit</button>
        </form>
    </div>
</div>




    
    <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2023 - Contact.MVC
        </div>
    </footer>
    <script src="../lib/jquery/dist/jquery.min.js"></script>
    <script src="../lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="../js/site.js" asp-append-version="true"></script>

    <!--#include virtual="/myapp/get-contact-process.asp"-->

    <script>

    let jsonR = <%= jsonResponse %>

    document.getElementById("name").value = jsonR.response.contact.name
    document.getElementById("surname").value = jsonR.response.contact.surname
    document.getElementById("email").value = jsonR.response.contact.email
    document.getElementById("phone").value = jsonR.response.contact.phone
    let attr = document.querySelector("form").getAttribute("action");
    attr+="?contactId=" + jsonR.response.contact.contactId;
    document.querySelector("form").setAttribute("action",attr);
    </script>

</body>
</html>