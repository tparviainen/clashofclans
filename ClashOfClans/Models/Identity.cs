namespace ClashOfClans.Models
{
    public class Identity
    {
        public string Tag;

        public string Name;

        public override string ToString()
        {
            return $"Tag {Tag}, Name '{Name}'";
        }
    }
}
