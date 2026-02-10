namespace TenantPM.Domain.Common
{
    public interface IBaseResponse
    {
        bool Success { get; }
        string Message { get; }
        List<string>? Errors { get; }
    }

    public interface IBaseResponse<out T> : IBaseResponse
    {
        T? Data { get; }
    }
}