using Microsoft.EntityFrameworkCore;
using System;
using WebApplication2.Application.Interfaces.Repositories;
using WebApplication2.Domain.Entities.Notion;
using WebApplication2.Domain.Entities.User;
using WebApplication2.Infrastucture.ApplicationDd;

namespace WebApplication2.Infrastucture.Repositories.NotionRepository
{
    public class NotionRepository : INotionRepository
    {


       
        
            private readonly ApplicationDbContext _context;
            public NotionRepository(ApplicationDbContext _dbcontext)
            {
                _context = _dbcontext;
            }
            public async Task<Notion> Create(Notion notion)
            {
                var creatuser = await _context.notions.AddAsync(notion);
                await _context.SaveChangesAsync();
                return creatuser.Entity;
            }
            public async Task<bool> Delete(Notion notion)
            {
                if (notion is not null)
                {
                    notion.AppAction = Domain.Enum.AddAction.AddAction.Deleted;
                    await _context.SaveChangesAsync();
                    return true;
                }


                else { return false; }

            }
            public async Task<Notion> Update(Notion notion)
            {
                if (notion is not null)
                {
                    _context.notions.Update(notion);
                    await _context.SaveChangesAsync();
                }
                return notion;
            }
        public async Task<Notion> GetById(int id)
        {
            var Findnoyion = await _context.notions.FindAsync(id);
            return Findnoyion;
        }
        //public  IQueryable<Notion> GetById(int id)
        //{
        //    var Findnotion =  _context.notions.Where(n => n.UserRef == id);
        //    return Findnotion;
        //}
        public IQueryable<Notion> GetAll()
            {
                var users = _context.notions.Where(x => x.AppAction == Domain.Enum.AddAction.AddAction.Active);
                return users;
            }



        
    }
}
