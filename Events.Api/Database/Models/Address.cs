namespace Events.Api.Database.Models
{
    public partial class Address
    {
        public Address()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
