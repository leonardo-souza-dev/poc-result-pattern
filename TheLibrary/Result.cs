using Microsoft.AspNetCore.Mvc.Filters;

namespace TheLibrary
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string? Message { get; }
        public string Status { get; }

        protected Result(bool isSuccess, string? message, string status)
        {
            IsSuccess = isSuccess;
            Message = message;
            Status = status;
        }

        public static Result Success(string status) => new(true, null, status);

        public static Result Failure(string errorMessage, string resultStatus) => new(false, errorMessage, resultStatus);
    }

    public class Result<T> : Result
    {
        public T? Value { get; }

        private Result(T? value, bool isSuccess, string? message, string status) : base(isSuccess, message, status)
        {
            Value = value;
        }

        public static Result<T> Success(T value, string status) => new(value, true, null, status);

        public new static Result<T> Failure(string error, string status) => new(default, false, error, status);
    }
}