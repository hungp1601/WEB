using System.Text.Json;
using NHNT.Constants.Statuses;

namespace NHNT.Dtos
{
    public class DataResponse<T>
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        private DataResponse() { }

        public static DataResponse<T> Build(IStatusError status)
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Code = status.GetCode();
            response.Message = status.GetMessage();

            return response;
        }

        public static DataResponse<T> Build()
        {
            return Build(StatusServer.SUCCESS);
        }

        public static DataResponse<T> Build(T data)
        {
            DataResponse<T> response = Build();
            response.Data = data;

            return response;
        }

        public static DataResponse<T> Build(IStatusError status, T data)
        {
            DataResponse<T> response = Build(status);
            response.Data = data;

            return response;
        }

        public static DataResponse<T> Build(int? code, string message)
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Code = code;
            response.Message = message;

            return response;
        }

        public static DataResponse<T> Build(int? code, string message, T data)
        {
            DataResponse<T> response = new DataResponse<T>();
            response.Code = code;
            response.Message = message;
            response.Data = data;

            return response;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}