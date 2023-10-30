namespace CrispChat.Net.Models
{
    public sealed class Result<T, E>
    {
        private T? _value;
        private E? _error;
        private bool _isSuccess;

        public bool IsSuccess => _isSuccess;
        public bool IsError => !_isSuccess;

        public Result<T, E> Ok(T? value) => new() { _value = value, _isSuccess = true };

        public Result<T, E> Err(E? error) => new() { _error = error, _isSuccess = false };

        public T? Value =>
            _isSuccess
                ? _value
                : throw new InvalidOperationException("Access is not allowed on an error result.");

        public E? Error =>
            _isSuccess
                ? throw new InvalidOperationException("Access is not allowed on a success result.")
                : _error;
    }

    public class ErrorResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Exception? Exception { get; set; }

        public ErrorResult(int status, string message)
        {
            Status = status;
            Message = message;
            Exception = null;
        }

        public ErrorResult(int status, string message, Exception exception)
        {
            Status = status;
            Message = message;
            Exception = exception;
        }
    }
}
