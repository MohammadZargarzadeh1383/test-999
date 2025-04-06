using WebApplication2.Domain.Entities.User;
namespace WebApplication2.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public  Task<User> Create(User user);
        public  Task<bool> Delete(User user);
        public Task<User> Update(User user);


        public Task<User> GetById(int id);
        public IQueryable<User> GetAll();

        public Task<int> GetId(int id);
    }
}
