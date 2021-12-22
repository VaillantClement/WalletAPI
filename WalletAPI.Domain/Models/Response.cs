namespace WalletAPI.Domain.Models
{
    public class Response
    {
        public Response()
        {
            Success = false;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
