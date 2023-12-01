namespace NHNT.Constants.Statuses
{
    public class StatusServer : IStatusError
    {
        public static readonly StatusServer SUCCESS = new StatusServer(200, "Thành công");
        public static readonly StatusServer BAD_REQUEST = new StatusServer(400, "Yêu cầu không hợp lệ");
        public static readonly StatusServer TOKEN_EXPIRED = new StatusServer(401, "Token hết hạn");
        public static readonly StatusServer TOKEN_INVALID = new StatusServer(402, "Token không hợp lệ");
        public static readonly StatusServer FORBIDDEN = new StatusServer(403, "Yêu cầu bị từ chối (không có quyền truy cập)");



        public static readonly StatusServer INTERNAL_SERVER_ERROR = new StatusServer(500_001, "Máy chủ gặp lỗi");
        public static readonly StatusServer USER_INFO_HAS_ERROR = new StatusServer(500_002, "Thông tin người dùng đang gặp lỗi (user = null)");
        public static readonly StatusServer USER_ROLES_HAS_ERROR = new StatusServer(500_003, "Thông tin quyền của người dùng đang gặp lỗi (roles = null)");

        //

        private int Code;
        private string Message;

        private StatusServer(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int GetCode()
        {
            return this.Code;
        }

        public string GetMessage()
        {
            return this.Message;
        }
    }
}