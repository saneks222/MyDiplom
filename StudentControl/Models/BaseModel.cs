namespace StudentControl.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; }
    }
}
