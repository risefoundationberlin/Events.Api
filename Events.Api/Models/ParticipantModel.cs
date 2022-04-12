namespace Events.Api.Models;

public class ParticipantModel
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? MobileNo { get; set; }
}