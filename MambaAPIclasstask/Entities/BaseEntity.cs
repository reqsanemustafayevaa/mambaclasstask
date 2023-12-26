namespace MambaAPIclasstask.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; } 
        public bool Isdeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
