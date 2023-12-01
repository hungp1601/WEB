namespace NHNT.Constants.Statuses
{
    public class StatusNotExist : IStatusError
    {
        public static readonly StatusNotExist UserId = new StatusNotExist(420_001, "Người dùng này không tồn tại (id)");
        public static readonly StatusNotExist REFRESH_TOKEN = new StatusNotExist(420_002, "Không tìm thấy refresh token trong cơ sở dữ liệu");
        public static readonly StatusNotExist ROLE_ID = new StatusNotExist(420_003, "Quyền này không tồn tại (id)");
        public static readonly StatusNotExist DEPARTMENT_ID = new StatusNotExist(420_004, "Phòng này không tồn tại (id)");
        public static readonly StatusNotExist DEPARTMENT_GROUP_ID = new StatusNotExist(420_005, "Nhóm phòng này không tồn tại (id)");
        public static readonly StatusNotExist IMAGE_ID = new StatusNotExist(420_006, "Ảnh này không tồn tại (id)");
        public static readonly StatusNotExist DEPARTMENT_STATUS = new StatusNotExist(420_007, "Trạng thái xét duyệt không tồn tại");


        //

        private int Code;
        private string Message;

        private StatusNotExist(int code, string message)
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