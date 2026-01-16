using System.Text.Json.Serialization;

namespace Common
{

    public class ApiResponse<T>
    {
        public int Code { get; set; }

        public string Message { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] // 数据为null时不序列化该字段
        public T? Data { get; set; }

        public Boolean Success { get; set; }

        public static ApiResponse<T> SuccessResult(T? data = default, string message = "操作成功")
        {
            return new ApiResponse<T>
            {
                Code = 200,
                Message = message,
                Success=true,
                Data = data,
            };
        }

        public static ApiResponse<T> ErrorResult(string message, int code = 500, T? data = default)
        {
            return new ApiResponse<T>
            {
                Code = code,
                Message = message,
                Success = false,
                Data = data,
            };
        }
    }

    public static class ApiResponse
    {
        public static ApiResponse<object> Success(object? data,string message = "操作成功")
        {
            return ApiResponse<object>.SuccessResult(data, message);
        }

        public static ApiResponse<object> Success(string message = "操作成功")
        {
            return ApiResponse<object>.SuccessResult(null, message);
        }

        public static ApiResponse<object> Error(string message, int code = 500)
        {
            return ApiResponse<object>.ErrorResult(message, code);
        }
    }

    public enum ApiCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 200,

        /// <summary>
        /// 服务器内部错误
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        /// 参数验证失败
        /// </summary>
        ParameterError = 400,

        /// <summary>
        /// 未授权
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// 资源不存在
        /// </summary>
        ResourceNotFound = 404,

        /// <summary>
        /// 业务逻辑错误
        /// </summary>
        BusinessError = 10001
    }

}
