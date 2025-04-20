using WebApplication3.Domain.Common.BaseEntity;

namespace WebApplication3.Domain.User
{
    public class User : BaseEntity
    {
        public string FullNmae { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
