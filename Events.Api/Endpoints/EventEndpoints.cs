using AutoMapper;
using Events.Api.Database.Models;
using Events.Api.Endpoints.Internal;
using Events.Api.Middleware;
using Events.Api.Models;
using Events.Api.Services.Implementations;
using Events.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Events.Api.Endpoints;

public class EventEndpoints : IEndpoints
{
    private const string ContentType = "application/json";
    private const string Tag = "Events";
    private const string Pattern = "events";
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(Pattern, CreateEventAsync)
            .WithName("CreateEvent")
            .Accepts<EventModel>(ContentType)
            .Produces<EventModel>(201)
            .Produces(400)
            .WithTags(Tag);
        
        app.MapGet($"{Pattern}/{{id}}", GetEventByIdAsync)
            .WithName("GetEvent")
            .Produces<EventModel>(200)
            .Produces(400) 
            .WithTags(Tag);
        
    }

    private static async Task<IResult> GetEventByIdAsync(string id, IEventService eventService, IMapper mapper)
    {
        if (!int.TryParse(id, out var eventId))
        {
            throw new ArgumentException("Invalid event id");
        }
        var eventData = await eventService.GetEventByIdAsync(eventId);
        return Results.Ok(mapper.Map<EventModel>(eventData));
    }

    private static async Task<IResult> CreateEventAsync(EventModel eventModel, IEventService eventService, IMapper mapper)
    {
        try
        {
            var eventData = mapper.Map<Event>(eventModel);
            eventData.CreatedAt = DateTime.UtcNow;
            eventData.UpdatedAt = DateTime.UtcNow;
            var createdEvent = await eventService.AddEventAsync(eventData);
            if (createdEvent.Id > 0)
            {
                return Results.CreatedAtRoute("GetEvent", new { id = createdEvent.Id }, mapper.Map<EventModel>(createdEvent));
            }
        }
        catch (Exception e)
        {
            throw new AppException("Could not create event", e);
        }
        
        return Results.BadRequest("Could not create event");
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IEventService, EventService>();
    }
}