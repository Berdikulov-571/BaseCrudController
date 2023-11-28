namespace ApiTutorials.Entities
{
    public class BaseEntity : Auditable
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
    }
}
