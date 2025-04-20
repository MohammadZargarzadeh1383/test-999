namespace WebApplication3.Domain.Common.BaseEntity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public string CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateAt { get; set; }

    }
}
