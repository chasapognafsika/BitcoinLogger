namespace BitcoinLogger.Api.Services.Shared
{
    public class ServiceOperationResult
    {
        public bool IsSuccessful { get; set; }
        public string Errors { get; set; }
        
        public static ServiceOperationResult Success => new ServiceOperationResult()
        {
            IsSuccessful = true
        };
        
        public static ServiceOperationResult Failure(string errors) => new ServiceOperationResult()
        {
            IsSuccessful = false,
            Errors = errors
        };
    }
    
    public class ServiceOperationResult<TData> : ServiceOperationResult
    {
        public TData Data { get; set; }
        
        public new static ServiceOperationResult<TData> Success(TData data) => new ServiceOperationResult<TData>()
        {
            IsSuccessful = true,
            Data = data
        };
        
        public new static ServiceOperationResult<TData> Failure(string errors) => new ServiceOperationResult<TData>()
        {
            IsSuccessful = false,
            Errors = errors
        };
    }
}