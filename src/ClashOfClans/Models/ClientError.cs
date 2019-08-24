using System;

namespace ClashOfClans.Models
{
    /// <summary>
    /// Error message from the endpoint
    /// </summary>
    [Serializable]
    public class ClientError
    {
        public string Reason { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Message}: {Reason}";
        }
    }
}
