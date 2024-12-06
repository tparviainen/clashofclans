namespace ClashOfClans.Models
{
    public class VerifyTokenResponse
    {
        public string Tag { get; set; } = default!;

        public string Token { get; set; } = default!;

        public Status Status { get; set; }
    }
}
