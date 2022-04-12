namespace Events.Api.Endpoints.Internal;

public interface IEndpoints
{
    public static abstract void DefineEndpoints(IEndpointRouteBuilder endpoints);
    
    public static abstract void AddServices(IServiceCollection services, IConfiguration configuration);
}