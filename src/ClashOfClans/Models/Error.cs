namespace ClashOfClans.Models
{
    public class Error
    {
        public string Reason { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Message}: {Reason}";
        }
    }
}
