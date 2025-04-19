namespace MizanGraduationProject.Data.Models.OTP
{
    public class VerifyOTP
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string UserID { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public User User { get; set; } = null!;
    }
}
