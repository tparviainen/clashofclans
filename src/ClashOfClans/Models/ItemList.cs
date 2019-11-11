namespace ClashOfClans.Models
{
    public class ItemList<T> : Queryable
    {
        public T Items { get; set; }
    }
}
