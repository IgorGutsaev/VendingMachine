using Filuet.ASC.OnBoard.Kernel.HostApp.Classes;
using Filuet.Utils.Encryption;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;
using System.Text;

namespace Filuet.ASC.OnBoard.Kernel.HostApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var key = GetKey();

            SetupLogger(key.Login);

            services.AddMvc();

            //services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton<FiluetASCApiHandlerForKiosk>(new FiluetASCApiHandlerForKiosk(Configuration["ApiUrl"], key.Login, key.Password));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }

        private KeyModel GetKey()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.key");

            if (files.Length == 0)
                throw new FileNotFoundException("Key file not found! Unable to authorize.");

            string keyFile = files[0];
            string login = Path.GetFileNameWithoutExtension(keyFile);

            DataProtectionClient client = new DataProtectionClient(Encoding.UTF8.GetBytes(login + login + login));
            return JsonConvert.DeserializeObject<KeyModel>(client.AsString(client.Unprotect(File.ReadAllBytes(keyFile))));
        }

        public class KeyModel
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

        private void SetupLogger(string partitionId)
        {
            Program._logBatchHoldPeriodSec = Convert.ToInt32(Configuration.GetSection("Serilog:LogBatchHoldPeriodSec").Value);
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .WriteTo.AzureTableStorage(CloudStorageAccount.Parse(Configuration.GetSection("ConnectionStrings:AzureStorageConnectionString").Value),
                    storageTableName: "onboardlogs", keyGenerator: new AscKeyGenerator(partitionId), writeInBatches: true, batchPostingLimit: 100, period: new System.TimeSpan(0, 0, Program._logBatchHoldPeriodSec))
                .CreateLogger();
        }
    }
}
