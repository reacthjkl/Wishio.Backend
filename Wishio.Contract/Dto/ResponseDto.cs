namespace Wishio.Contract.Dto;

public class ResponseDto<T>
{
    public bool Successful { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static ResponseDto<T> Success(T data)
    {
        return new ResponseDto<T>
        {
            Successful = true,
            Data = data
        };
    }

    public static ResponseDto<T> Success()
    {
        return new ResponseDto<T>
        {
            Successful = true
        };
    }

    public static ResponseDto<T> Fail(string errorMessage)
    {
        return new ResponseDto<T>
        {
            Successful = false,
            Message = errorMessage
        };
    }

    public static ResponseDto<List<T>> SuccessList(IEnumerable<T> data)
    {
        return new ResponseDto<List<T>>
        {
            Successful = true,
            Data = data.ToList()
        };
    }
}