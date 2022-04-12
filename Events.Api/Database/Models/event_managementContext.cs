using Microsoft.EntityFrameworkCore;

namespace Events.Api.Database.Models
{
    public partial class event_managementContext : DbContext
    {
        public event_managementContext()
        {
        }

        public event_managementContext(DbContextOptions<event_managementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventParticipant> EventParticipants { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(5)
                    .HasColumnName("house_number");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(5)
                    .HasColumnName("postal_code");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(50)
                    .HasColumnName("street_name");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DeadlineDate).HasColumnName("deadline_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.EventBannerUrl)
                    .HasMaxLength(100)
                    .HasColumnName("event_banner_url");

                entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.ParticipantsLimit).HasColumnName("participants_limit");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.StatusId).HasColumnName("status");

                entity.Property(e => e.TypeId).HasColumnName("event_type");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("address_fkey");

            });

            modelBuilder.Entity<EventParticipant>(entity =>
            {
                entity.ToTable("event_participants");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.IsCancelled).HasColumnName("is_cancelled");

                entity.Property(e => e.ParticipantId).HasColumnName("participant_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventParticipants)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("events_fkey");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.EventParticipants)
                    .HasForeignKey(d => d.ParticipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("participants_fkey");
            });


            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("participants");

                entity.HasIndex(e => e.Email, "participants_email_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasColumnType("character varying")
                    .HasColumnName("full_name");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .HasColumnName("mobile_no");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
