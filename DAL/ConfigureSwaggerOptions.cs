using System;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace ApiVersioning.DAL
{
	public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
	{
        private readonly IApiVersionDescriptionProvider _apiVersion;
		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersion)
		{
            _apiVersion = apiVersion;
		}

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var item in _apiVersion.ApiVersionDescriptions)
            {
                options.SwaggerDoc(item.GroupName, CreateVersionInfo(item));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Your versioned Api",
                Version = description.ApiVersion.ToString()
            };

            return info;
        }
    }
}

