using System.ComponentModel.DataAnnotations;
using WebApplication2.Domain.common;


namespace WebApplication2.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public int Mobile { get; set; }
        
        public string? UserName { get; set; }

        public string Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public IList<WebApplication2.Domain.Entities.Notion.Notion>? Notions { get; set; }
    }
}
