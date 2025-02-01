namespace MyInventory.API.ViewModels
{
    public class EquipmentQueryViewModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }
        public string? SearchQuery { get; set; }
    }
}
