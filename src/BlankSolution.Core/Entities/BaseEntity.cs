namespace BlankSolution.Core.Entities
{
    public class BaseEntity
    {
        public int id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
