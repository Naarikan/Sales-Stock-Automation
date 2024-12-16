namespace Blazor.API.ViewModels.Category
{
    public class GetCategoryViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string Name { get; set; }
    }
}
