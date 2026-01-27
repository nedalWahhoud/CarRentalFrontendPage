namespace CarRentalFrontendPage.Models
{
    public class GetItems<T>
    {
        public List<T> Items { get; set; } = [];
        public bool AllItemsLoaded { get; set; }
        public List<int> excludedCarIds { get; set; } = [];
        public int PageSize { get; set; } = 2;
    }
}
