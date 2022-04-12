namespace Events.Api.Models;

public class EventModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime DeadlineDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string EventBannerUrl { get; set; } = null!;
    public short? ParticipantsLimit { get; set; }
    public AddressModel? Address { get; set; }
    public EventType Type { get; set; }
    public EventStatus Status { get; set; }
}