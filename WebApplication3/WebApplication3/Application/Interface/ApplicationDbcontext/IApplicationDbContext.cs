using Microsoft.EntityFrameworkCore;
using System;
using WebApplication3.Domain.Attendance;
using WebApplication3.Domain.Common.BaseEntity;
using WebApplication3.Domain.User;

namespace WebApplication3.Application.Interface.ApplicationDbcontext
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Attendance> Attendances { get; }

        public DbSet<TEntity> SetDbset<TEntity>() where TEntity : BaseEntity;
    }
}
