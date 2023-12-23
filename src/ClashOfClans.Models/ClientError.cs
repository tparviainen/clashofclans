namespace ClashOfClans.Models
{
    /// <summary>
    /// Error message from the endpoint
    /// </summary>
    public class ClientError
    {
        public string Reason { get; set; } = default!;

        public string Message { get; set; } = default!;

        public override string ToString() => $"Reason '{Reason}', message '{Message}'";
    }
}
