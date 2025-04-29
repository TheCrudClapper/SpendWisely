namespace Entities.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
