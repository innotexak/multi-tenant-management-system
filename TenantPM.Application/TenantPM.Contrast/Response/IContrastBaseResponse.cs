namespace TenantPM.Domain.Common
{
    public interface IContrastBaseResponse
    {
        bool Success { get; }
        string Message { get; }
        List<string>? Errors { get; }
    }

    public interface IContrastBaseResponse<out T> : IContrastBaseResponse
    {
        T? Data { get; }
    }
}