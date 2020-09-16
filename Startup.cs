//Parial Starup.cs file

// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
           //Add service reference to Email Setting Meta Data that is present in appsettings.json file
            var emailMetaData = Configuration.GetSection("EmailSettingsMetaData").
                Get<EmailSettingsMetaData>();
            services.AddSingleton(emailMetaData);
            services.AddControllers();
        }
