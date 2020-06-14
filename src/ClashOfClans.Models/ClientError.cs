using System;

namespace ClashOfClans.Models
{
    /// <summary>
    /// Error message from the endpoint
    /// </summary>
    [Serializable]
    public class ClientError
    {
        public string Reason { get; set; } = default!;

        public string Message { get; set; } = default!;
    }
}
