using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PictureShare_.Models;

namespace PictureShare_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<PictureModel> Pictures { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}