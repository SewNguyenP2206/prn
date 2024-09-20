using Microsoft.EntityFrameworkCore;
using System;

namespace BussinessObjects.Models
{
    public class ConvosDbContext : DbContext
    {
        public ConvosDbContext() { }

        public ConvosDbContext(DbContextOptions<ConvosDbContext> options)
            : base(options)
        { }

        // DbSet properties for all models
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<ServerMember> ServerMembers { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<MemberRole> MemberRoles { get; set; }
        public virtual DbSet<InviteUsage> InviteUsages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            base.OnModelCreating(modelBuilder);

            // Composite key for 'MemberRole' table
            modelBuilder.Entity<MemberRole>()
                .HasKey(mr => new { mr.MemberId, mr.RoleId });

            // Configure the relationship between User and Friendship (Requester)
            modelBuilder.Entity<User>()
                .HasMany(u => u.RequestedFriendships)
                .WithOne(f => f.Requester)
                .HasForeignKey(f => f.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);  // No cascading delete

            // Configure the relationship between User and Friendship (Addressee)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedFriendships)
                .WithOne(f => f.Addressee)
                .HasForeignKey(f => f.AddresseeId)
                .OnDelete(DeleteBehavior.Restrict);  // No cascading delete

            // Primary key and unique constraint for Friendship
            modelBuilder.Entity<Friendship>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Friendship>()
                .HasIndex(f => new { f.RequesterId, f.AddresseeId })
                .IsUnique();

            // Relationships for 'ServerMember'
            modelBuilder.Entity<ServerMember>()
                .HasOne(sm => sm.Server)
                .WithMany(s => s.ServerMembers)
                .HasForeignKey(sm => sm.ServerId);

            modelBuilder.Entity<ServerMember>()
                .HasOne(sm => sm.Member)
                .WithMany(u => u.ServerMembers)
                .HasForeignKey(sm => sm.UserId);

            // Relationships for 'MemberRole'
            modelBuilder.Entity<MemberRole>()
                .HasOne(mr => mr.Role)
                .WithMany(r => r.MemberRoles)
                .HasForeignKey(mr => mr.RoleId);

            modelBuilder.Entity<MemberRole>()
                .HasOne(mr => mr.ServerMember)
                .WithMany(sm => sm.MemberRoles)
                .HasForeignKey(mr => mr.MemberId);
        }


    }
}
