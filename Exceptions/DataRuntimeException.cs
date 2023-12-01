using System;
using NHNT.Constants.Statuses;

namespace NHNT.Exceptions
{
    public class DataRuntimeException : ApplicationException
    {
        public int ErrorCode { get; }
        public string ErrorMessage { get; }
        public Exception ErrorCause { get; } // Nguyên nhân

        public DataRuntimeException(int code, string message)
        {
            ErrorCode = code;
            ErrorMessage = message;
        }

        public DataRuntimeException(int code, string format, params object[] values)
        {
            ErrorCode = code;
            ErrorMessage = string.Format(format, values);
        }

        public DataRuntimeException(IStatusError status)
        {
            ErrorCode = status.GetCode();
            ErrorMessage = status.GetMessage();
        }

        public DataRuntimeException(IStatusError status, Exception cause)
        {
            ErrorCode = status.GetCode();
            ErrorMessage = status.GetMessage();
            ErrorCause = cause;
        }
    }
}