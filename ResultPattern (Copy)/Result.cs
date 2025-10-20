namespace ResultPattern
{
    public sealed class Result<T>
    {
        public T? Data { get; private set; }
        public Failure? Failure { get; private set; }
        public bool IsSuccess => Failure == null;
        public bool IsFailure => !IsSuccess;

        private Result(T data) { Data = data; }
        private Result(Failure failure) { Failure = failure; }
        public static Result<T> AsSuccess (T success) => new(success);
        public static Result<T> AsFailure (Failure failure) => new(failure);
    }
}