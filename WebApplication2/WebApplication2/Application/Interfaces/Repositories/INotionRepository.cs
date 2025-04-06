using WebApplication2.Domain.Entities.Notion;
using WebApplication2.Domain.Entities.User;

namespace WebApplication2.Application.Interfaces.Repositories
{
    public interface INotionRepository
    {
        public  Task<Notion> Create(Notion notion);
        public  Task<bool> Delete(Notion notion);
        
        public Task<Notion> Update(Notion notion);


        public Task<Notion> GetById(int id);
        public IQueryable<Notion> GetAll();
    }
}
