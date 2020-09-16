//Model class to inject Email Settings from app settings into controller via Startup.cs   

public class EmailSettingsMetaData
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
