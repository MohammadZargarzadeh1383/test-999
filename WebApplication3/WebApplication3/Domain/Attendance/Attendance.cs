using WebApplication3.Domain.Common.BaseEntity;

namespace WebApplication3.Domain.Attendance
{
    public class Attendance : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public int Time { get; set; }

    }
}
