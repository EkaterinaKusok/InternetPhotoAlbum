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


    }
}
