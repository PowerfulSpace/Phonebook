using PS.Phonebook.Domain.Enums;

namespace PS.Phonebook.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; } = null!;
        public StatusCode StatusCode { get; set; }
        public T? Data { get; set; }
    }
}
