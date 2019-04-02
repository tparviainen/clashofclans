namespace ClashOfClans.Models
{
    public class Error
    {
        public string Reason;

        public string Message;

        public override string ToString()
        {
            return $"{Message}: {Reason}";
        }
    }
}
