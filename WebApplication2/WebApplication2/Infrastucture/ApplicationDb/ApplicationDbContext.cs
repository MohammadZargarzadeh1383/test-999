using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.Application.Interfaces.ApplicationDd;
using WebApplication2.Domain.common;
using WebApplication2.Domain.Entities.Notion;
using WebApplication2.Domain.Entities.User;

namespace WebApplication2.Infrastucture.ApplicationDd
{

    public class ApplicationDbContext : DbContext , IApplicationDbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options , IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public DbSet<User> users => Set<User>();//توی دیتابیس اینجوری جدول درست می کنند 
        public DbSet<Notion> notions => Set<Notion>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)//اینا ثابت اند
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TEntity> SetDbset<TEntity>()  where TEntity : BaseEntity => Set<TEntity>();

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)// اینا ثابت اند
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
    
}
