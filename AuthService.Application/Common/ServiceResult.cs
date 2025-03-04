namespace AuthService.Application.Common
{
    public class ServiceResult<T>
    {
        public ResponseStatus Status { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public static ServiceResult<T> Success(T data, string message = "عملیات با موفقیت انجام شد")
        {
            return new ServiceResult<T> { Status = ResponseStatus.Success, Data = data, Message = message };
        }

        public static ServiceResult<T> Error(string message, List<string>? errors = null)
        {
            return new ServiceResult<T> { Status = ResponseStatus.Error, Message = message, Errors = errors };
        }

        public static ServiceResult<T> NotFound(string message = "موردی با این مشخصات یافت نشد")
        {
            return new ServiceResult<T> { Status = ResponseStatus.NotFound, Message = message };
        }

        public static ServiceResult<T> ValidationError(List<string> errors)
        {
            return new ServiceResult<T> { Status = ResponseStatus.ValidationError, Message = "خطایی در پردازش درخواست رخ داده است", Errors = errors };
        }

        public static ServiceResult<T> Unauthorized(string message = "شما مجاز به انجام این عملیات نیستید")
        {
            return new ServiceResult<T> { Status = ResponseStatus.Unauthorized, Message = message };
        }
    }

}
