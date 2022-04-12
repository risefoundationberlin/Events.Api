namespace Events.Api.Database.Models
{
    public partial class Event
    {
        public Event()
        {
            EventParticipants = new HashSet<EventParticipant>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int TypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string EventBannerUrl { get; set; } = null!;
        public short? ParticipantsLimit { get; set; }
        public int? AddressId { get; set; }
        public int StatusId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<EventParticipant> EventParticipants { get; set; }
    }
}
