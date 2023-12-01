namespace NHNT.Constants.Statuses
{
    public class StatusExist : IStatusError
    {
        public static readonly StatusExist USERNAME_IS_EXSIT = new StatusExist(410_001, "Tên đăng nhập đã tồn tại");
        public static readonly StatusExist EMAIL_IS_EXSIT = new StatusExist(410_001, "Email đã tồn tại");
        public static readonly StatusExist PHONE_IS_EXSIT = new StatusExist(410_001, "Số điện thoại đã tồn tại");


        //

        private int Code;
        private string Message;

        private StatusExist(int code, string message)
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