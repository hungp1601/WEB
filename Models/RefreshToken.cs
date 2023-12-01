using System;
using System.ComponentModel.DataAnnotations;

namespace NHNT.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Value { get; set; } // chính là refresh token - giá trị thực
        public string JwtId { get; set; } // giúp đạnh danh access token, làm cho token là duy nhất, có thể dựa vào đây để thu hồi token
        public bool? IsUsed { get; set; } // kiểm tra xem refresh token đã được sử dụng chưa
        public bool? IsRevoked { get; set; } // kiểm tra xem refresh token có bị thuh hồi chưa
        public DateTime? IssuedAt { get; set; } // thời điểm refresh token được tạo
        public DateTime? ExpiredAt { get; set; } // thời điểm refresh token hết hạn
    }
}