using WebApplication2.Domain.Enum.AddAction;

namespace WebApplication2.Domain.common
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public AddAction AppAction { get; set; }
    }
}
