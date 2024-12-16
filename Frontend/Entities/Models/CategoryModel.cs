namespace Entities.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string Name { get; set; }
    }
}
