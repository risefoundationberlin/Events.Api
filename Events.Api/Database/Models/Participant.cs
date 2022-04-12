namespace Events.Api.Database.Models
{
    public partial class Participant
    {
        public Participant()
        {
            EventParticipants = new HashSet<EventParticipant>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? MobileNo { get; set; }

        public virtual ICollection<EventParticipant> EventParticipants { get; set; }
    }
}
