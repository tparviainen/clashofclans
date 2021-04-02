namespace ClashOfClans.Models
{
    public class VerifyTokenResponse
    {
        private Status? _status;

        public string Tag { get; set; } = default!;

        public string Token { get; set; } = default!;

        public Status Status { get => _status ?? default; set => _status = value; }
    }
}
