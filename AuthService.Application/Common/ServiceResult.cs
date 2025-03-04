namespace AuthService.Application.Common
{
    public class ServiceResult
    {
        public ResponseStatus Status { get; set; }
        public string Token { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
    }
}
