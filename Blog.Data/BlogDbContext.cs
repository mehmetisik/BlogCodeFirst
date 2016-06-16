using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Blog.Data
{
    class BlogDbContext : DbContext
    {

        public DbSet<Articles> Articles { get; set; }
        public DbSet<ArticleTypes> ArticleTypes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>()
                .HasMany<Images>(s => s.Image)
                .WithMany(c => c.Article)
                .Map(cs =>
                {
                    cs.MapLeftKey("ArticleID");
                    cs.MapRightKey("ImageID");
                    cs.ToTable("ArticleImages");
                });

            modelBuilder.Entity<Articles>()
                .HasMany<Tags>(t => t.Tag)
                .WithMany(a => a.Article)
                .Map(ta =>
                {
                    ta.MapLeftKey("ArticleID");
                    ta.MapRightKey("TagID");
                });

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
