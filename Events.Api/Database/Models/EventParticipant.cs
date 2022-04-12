namespace Events.Api.Database.Models
{
    public partial class EventParticipant
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual Participant Participant { get; set; } = null!;
    }
}
