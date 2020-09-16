# send-emails-using-SMTP-on-asp-.net-core
Small project to send emails using SMPT on ASP .Net Core

This is an ASP .Net core project to send emails from a website to the website admin. It uses .Net MAILKIT SMTP client and .NET MVC.
The email server settings are present in the appsettings.json file. These are then injected into the controller using Add Singleton 
method in the Startup.cs file.

Send email method in the controller then sends out an email and shows a success/error message to the user via the View Message.
