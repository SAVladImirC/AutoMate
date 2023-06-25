namespace Data.Responses
{
#nullable disable
    public class SuccessResponse<T> : Response
    {
        public T Data { get; set; }
    }
}
