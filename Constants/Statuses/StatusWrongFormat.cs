namespace NHNT.Constants.Statuses
{
    public class StatusWrongFormat : IStatusError
    {
        public static readonly StatusWrongFormat USER_IS_NULL = new StatusWrongFormat(430_001, "Không thể tương tác với user bị null");
        public static readonly StatusWrongFormat USERNAME_OR_PASSWORD_WRONG_FROMAT = new StatusWrongFormat(430_002, "Tên tài khoản hoặc mật khẩu không đúng");
        public static readonly StatusWrongFormat ACCESS_TOKEN_EMPTY = new StatusWrongFormat(430_003, "Access token đang bị rỗng");
        public static readonly StatusWrongFormat REFRESH_TOKEN_EMPTY = new StatusWrongFormat(430_004, "Refresh token đang bị rỗng");
        public static readonly StatusWrongFormat REFRESH_TOKEN_IS_REVOKED = new StatusWrongFormat(430_005, "Refresh token này đã bị hủy bỏ");
        public static readonly StatusWrongFormat ACCESS_TOKEN_ID_NOT_MATCH_JTI = new StatusWrongFormat(430_006, "Access token id không khớp với refesh token");
        public static readonly StatusWrongFormat USERNAME_IS_EMPTY = new StatusWrongFormat(430_007, "Tên đăng nhập không được bỏ trống (username = null)");
        public static readonly StatusWrongFormat ROLE_IS_NULL = new StatusWrongFormat(430_008, "Không thể tương tác với role bị null");
        public static readonly StatusWrongFormat DEPARTMENT_IS_NULL = new StatusWrongFormat(430_009, "Không thể tương tác với department bị null");
        public static readonly StatusWrongFormat DEPARTMENT_GROUP_IS_NULL = new StatusWrongFormat(430_010, "Không thể tương tác với department group bị null");
        public static readonly StatusWrongFormat IMAGE_IS_NULL = new StatusWrongFormat(430_011, "Không thể tương tác với image bị null");
        public static readonly StatusWrongFormat EMAIL_IS_EMPTY = new StatusWrongFormat(430_012, "Email không được bỏ trống (email = null)");
        public static readonly StatusWrongFormat PHONE_IS_EMPTY = new StatusWrongFormat(430_013, "Số điện thoại không được bỏ trống (phone = null)");
        public static readonly StatusWrongFormat FULL_NAME_IS_EMPTY = new StatusWrongFormat(430_014, "Họ và tên không được bỏ trống (phone = null)");
        public static readonly StatusWrongFormat PASSWORD_IS_EMPTY = new StatusWrongFormat(430_015, "Mật khẩu không được bỏ trống (phone = null)");
        public static readonly StatusWrongFormat RE_PASSWORD_IS_EMPTY = new StatusWrongFormat(430_016, "Mật khẩu nhập lại không được bỏ trống (phone = null)");
        public static readonly StatusWrongFormat RE_PASSWORD_NOT_SAME_PASSWORD = new StatusWrongFormat(430_017, "Mật khẩu nhập lại không giống");
        public static readonly StatusWrongFormat USER_ROLE_IS_NULL = new StatusWrongFormat(430_018, "Không thể tương tác với userRole bị null");

        //

        private int Code;
        private string Message;

        private StatusWrongFormat(int code, string message)
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