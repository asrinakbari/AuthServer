namespace AuthService.Grpc.Services.Interfaces
{
    public interface IAuthGrpcService
    {
        Task<ServiceResultReply> CreateUserAsync(UserSignUpRequest request);
        Task<ServiceResultReply> LoginAsync(LoginRequest request);
    }
}
