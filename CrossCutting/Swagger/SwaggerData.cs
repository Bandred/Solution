using Microsoft.Extensions.Configuration;

namespace CrossCutting.Swagger
{
    public class SwaggerData : ISwaggerData
    {
        private readonly IConfiguration _configuration;

        public SwaggerData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Title => _configuration.GetSection("SwaggerConfig:Title").Value;
        public string Version => _configuration.GetSection("SwaggerConfig:Version").Value;
        public string Xml => _configuration.GetSection("SwaggerConfig:Xml").Value;
    }

    public static class AddSwaggerData
    {
        public static SwaggerData New(IConfiguration config)
        {
            return new SwaggerData(config);
        }
    }
}
