using System.Collections.Generic;

namespace ORM
{
    using System;
    using System.Data.Entity;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public EntityModel(string connection)
            : base(connection)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Rating>Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(c => c.Roles)
                .WithMany(s => s.Users)
                .Map(t => t.MapLeftKey("UserId")
                    .MapRightKey("RoleId")
                    .ToTable("UserRoles"));
            modelBuilder.Entity<UserProfile>()
                .HasMany(e => e.Photos)
                .WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UserProfile>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Photo>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.Photo)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasOptional(s => s.UserProfile) // Mark Profilr property optional in User entity
                .WithRequired(ad => ad.User); // mark User property as required in Profile entity. Cannot save Profile without User

        }
    }
}
