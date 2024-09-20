using Microsoft.EntityFrameworkCore;
using System;

namespace BussinessObjects.Models
{
    public class ConvosDbContext : DbContext
    {
        public ConvosDbContext(DbContextOptions<ConvosDbContext> options)
            : base(options)
        { }

        // DbSet properties for all models
        public DbSet<User> Users { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<ServerMember> ServerMembers { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<InviteUsage> InviteUsages { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<ChannelRolePermission> ChannelRolePermissions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for 'MemberRole' table
            modelBuilder.Entity<MemberRole>()
                .HasKey(mr => new { mr.MemberId, mr.RoleId });

            // Restrict cascading deletes for the Friendships table to avoid multiple cascade paths
            modelBuilder.Entity<User>()
                .HasMany(u => u.RequestedFriendships)
                .WithOne(f => f.Requester)
                .HasForeignKey(f => f.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of user if they are an initiator

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedFriendships)
                .WithOne(f => f.Addressee)
                .HasForeignKey(f => f.AddresseeId)
                .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of user if they are a receiver

            // Configure the Friendship entity
            modelBuilder.Entity<Friendship>()
                .HasKey(f => f.Id);

            // Ensure a unique friendship between two users (Requester and Addressee)
            modelBuilder.Entity<Friendship>()
                .HasIndex(f => new { f.RequesterId, f.AddresseeId })
                .IsUnique();

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Requester)
                .WithMany(f => f.RequestedFriendships)
                .HasForeignKey(f => f.RequesterId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Addressee)
                .WithMany(f => f.ReceivedFriendships)
                .HasForeignKey(f => f.AddresseeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

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
                .HasForeignKey(mr => mr.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MemberRole>()
                .HasOne(mr => mr.ServerMember)
                .WithMany(sm => sm.MemberRoles)
                .HasForeignKey(mr => mr.MemberId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<InviteUsage>()
             .HasOne(iu => iu.Invite)
            .WithMany()
            .HasForeignKey(iu => iu.InviteId);

            modelBuilder.Entity<Server>()
                .HasMany(s => s.Invites)
                .WithOne(i => i.Server)
                .HasForeignKey(i => i.ServerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ServerMember>()
              .HasMany(sm => sm.Invites)
              .WithOne(i => i.ServerMember)
              .HasForeignKey(i => i.CreatorId)
              .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<RolePermission>()
        .HasOne(rp => rp.Role)
        .WithMany()
        .HasForeignKey(rp => rp.RoleId)
              .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany()
                .HasForeignKey(rp => rp.PermissionId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ChannelRolePermission>()
              .HasOne(rp => rp.Role)
              .WithMany()
              .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ChannelRolePermission>()
             .HasOne(rp => rp.Permission)
             .WithMany()
             .HasForeignKey(rp => rp.PermissionId)
           .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ChannelRolePermission>()
             .HasOne(rp => rp.Channel)
             .WithMany()
             .HasForeignKey(rp => rp.ChannelId)
           .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Channel>()
           .HasOne(ch => ch.Category)
           .WithMany()
           .HasForeignKey(ch => ch.CategoryId)
         .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }


}
