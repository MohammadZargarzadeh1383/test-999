using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication3.Domain.User;
using WebApplication3.Infrastucture.ApplicationDbContext;

namespace WebApplication3.Infrastucture.Repositories.UsreRepository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext.ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext.ApplicationDbContext _dbcontext)
        {
            _context = _dbcontext;
        }
        public async Task<User> GetUsers()
        {
            var CheckTime = DateTime.Now;
            var users = await _context.Users.ToListAsync();

            var attendances = await _context.Attendances
                .Where(a => a.DateTime == CheckTime)
                .ToListAsync();

            var result = users.Select(user =>
            {
                var count = attendances.Count(a => a.UserId == user.Id);
                var status = (count % 2 == 1) ? "Present" : "Absent";

                return new
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    AttendanceCount = count,
                    Status = status
                };
            });


        }
    }

}
