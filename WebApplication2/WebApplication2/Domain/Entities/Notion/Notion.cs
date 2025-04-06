using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Domain.common;
using WebApplication2.Domain.Entities.User;

namespace WebApplication2.Domain.Entities.Notion
{
    public class Notion : BaseEntity
    {
        public int UserRef { get; set; }
        [ForeignKey("UserRef")]
        public WebApplication2.Domain.Entities.User.User User { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        
        public string Description { get; set; }


    }
}
