using PS.Phonebook.Domain.Enums;

namespace PS.Phonebook.Domain.Response
{
    public interface IBaseResponse<T>
    {
        public StatusCode StatusCode { get; }
        public T? Data { get; }
    }
}
