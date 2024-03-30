namespace Fujitsu.Models
{
    public class BaseModelResponse<T>
    {
        public bool isError { get; set; }
        public string isMessage { get; set; }
        public T Data { get; set; }
        public List<T> DataList { get; set; }
    }

    public class BaseModelResponse
    {
        public string isMessege { get; set; }
        public bool isError { get; set; }
        public string code { get; set; }
    }
}
