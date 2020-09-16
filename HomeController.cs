//this is the partial controller class

//Install .NET MAILKIT from NUGET
using MailKit.Net.Smtp;

  public class HomeController : Controller
    {
        private EmailSettingsMetaData _emailMetaData;
        
        //Inject Email Settings Meta Data into the controller
        public HomeController(EmailSettingsMetaData emailData)
        {
            _emailMetaData = emailData;
        }
        
        
        //Action method called on click on submit button on View
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection formData)
        {
            var name = formData["name"];
            var email = formData["email"];
            var phone = formData["phone"];
            var message = formData["message"];

            string sent;

            sent = await SendEmail(name, email, phone, message);
            if (sent == "sent")
                ViewBag.Message = Constants.SUCCESS_MESSAGE;
            else
                ViewBag.Message = Constants.ERROR_MESSAGE;
            return View();

        }
        
        //Send email function uses .NET MAILKIT SMTP Client
        private async Task<string> SendEmail(string name, string email, string phone, string message)
        {
            var msg = new MimeMessage();
            msg.From.Add(MailboxAddress.Parse(Constants.FROM_EMAIL_ID_TEST));
            msg.To.Add(MailboxAddress.Parse(Constants.TO_EMAIL_ID_TEST));
            msg.Subject = "Lead Generated on Octa Foods website";
            msg.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            { Text = ($"Lead Generated on octafoods.co.in. Name: {name}, Email: {email}, Phone: {phone}, Message: {message}")};
            try
            {
                //send email 
                using (SmtpClient smtp = new SmtpClient())
                {
                       
                    await smtp.ConnectAsync(_emailMetaData.SmtpServer,
                    _emailMetaData.Port,MailKit.Security.SecureSocketOptions.None);
                    await smtp.AuthenticateAsync(_emailMetaData.UserName,
                    _emailMetaData.Password);
                    await smtp.SendAsync(msg);
                    await smtp.DisconnectAsync(true);
                    return "sent";
                }
            }

            catch (SmtpProtocolException ex)
            {
                return ex.Message;
            }
        }
    }
