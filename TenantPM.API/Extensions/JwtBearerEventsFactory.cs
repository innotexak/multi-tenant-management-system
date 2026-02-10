using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;

namespace TenantPM.API.Authentication
{
    public static class JwtBearerEventsFactory
    {
        public static JwtBearerEvents Create()
        {
            return new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.HandleResponse();

                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        success = false,
                        status = 401,
                        message = "Authentication token is missing or invalid"
                    };

                    return context.Response.WriteAsync(
                        JsonSerializer.Serialize(response)
                    );
                },

                OnForbidden = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        success = false,
                        status = 403,
                        message = "You do not have permission to access this resource"
                    };

                    return context.Response.WriteAsync(
                        JsonSerializer.Serialize(response)
                    );
                }
            };
        }
    }
}
