namespace ClashOfClans.Models
{
    public class Identity
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Tag {Tag}, Name '{Name}'";
        }
    }
}
