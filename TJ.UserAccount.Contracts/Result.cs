namespace TJ.UserAccount.Contracts
{
    public class Result<TValue>
    {
        public bool IsSuccess{ get; set; }
        public string Message { get; set; }
        public TValue Value { get; set; }
        public static Result<TValue> Ok(TValue value) =>
            new Result<TValue>
            {
                IsSuccess = true,
                Value = value
            };
        public static Result<TValue> Error(string message) =>
            new Result<TValue>
            {
                IsSuccess = false,
                Message = message
            };
    }
}
