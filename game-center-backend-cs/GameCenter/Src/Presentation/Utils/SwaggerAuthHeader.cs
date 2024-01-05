using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace game_center_backend_cs.Presentation.Utils;

public class SwaggerAuthHeader : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "UserId",
            In = ParameterLocation.Header,
            Schema = new OpenApiSchema { Type = "String" },
            Required = false
        });
    }
}