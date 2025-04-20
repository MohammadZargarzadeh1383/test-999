using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using WebApplication3.Domain.Common.BaseEntity;
using WebApplication3.Domain.User;
using WebApplication3.Domain.Attendance;
using WebApplication3.Application.Interface.ApplicationDbcontext;

namespace WebApplication3.Infrastucture.ApplicationDbContext
{


    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public DbSet<User> Users => Set<User>();//توی دیتابیس اینجوری جدول درست می کنند 
        public DbSet<Attendance> Attendances => Set<Attendance>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)//اینا ثابت اند
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TEntity> SetDbset<TEntity>() where TEntity : BaseEntity => Set<TEntity>();

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)// اینا ثابت اند
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}

