using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ups.micros.chat.api.Extensions
{
    public static class Extension
    {
        public static void AddSwaggerDocumentation(this SwaggerGenOptions o)
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        }
    }
}
