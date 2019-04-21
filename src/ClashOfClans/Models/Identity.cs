namespace ClashOfClans.Models
{
    /// <summary>
    /// Represents the identity of the object in terms of name and tag.
    /// </summary>
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
