namespace Domain.Helpers.Entities
{
    public class GroupedStatistics<T>
    {
        public string Key { get; set; }
        public List<T> Items { get; set; }
    }
}
