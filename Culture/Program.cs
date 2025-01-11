namespace Culture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // اضافه کردن تنظیمات Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            // اضافه کردن کنترلرها و تنظیمات Localization
            builder.Services.AddControllers()
                .AddDataAnnotationsLocalization()
                .AddViewLocalization();

            // اضافه کردن Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var supportedCultures = new[] { "fa-IR", "en-US", "ar-SA" }; // زبان‌های پشتیبانی شده
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            // فعال کردن Middleware برای Localization
            app.UseRequestLocalization(localizationOptions);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
