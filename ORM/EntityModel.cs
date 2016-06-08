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
        public virtual DbSet<Photo> Photos { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Role>()
        //        .HasMany(e => e.Users)
        //        .WithRequired(e => e.Role)
        //        .WillCascadeOnDelete(false);
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasMany(c => c.Roles)
            //    .WithMany(s => s.Users)
            //    .Map(t => t.MapLeftKey("UserId")
            //        .MapRightKey("RoleId")
            //        .ToTable("UserRoles"));
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Photos)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }

    }

}
