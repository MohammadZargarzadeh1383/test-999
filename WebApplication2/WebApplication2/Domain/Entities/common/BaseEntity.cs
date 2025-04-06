using WebApplication2.Domain.Enum.AddAction;

namespace WebApplication2.Domain.common;


public class BaseEntity : IBaseEntity
{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public AddAction AppAction { get; set; } = AddAction.Active;
}
