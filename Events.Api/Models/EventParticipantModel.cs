namespace Events.Api.Models;

public class EventParticipantModel
{
    public int EventId { get; set; }
    public int ParticipantId { get; set; }
    public bool IsCancelled { get; set; }
}