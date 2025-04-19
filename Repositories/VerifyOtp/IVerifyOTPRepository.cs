using MizanGraduationProject.Repositories.Crud;

namespace MizanGraduationProject.Repositories.VerifyOtp
{
    public interface IVerifyOTPRepository : ICrud<Data.Models.OTP.VerifyOTP>
    {
        public Task<Data.Models.OTP.VerifyOTP> GetByUserIdAsync(string userid);
        public Task<bool> DeleteByUserIdAsync(string userid);
        public Task<bool> ExistsByUserIdAsync(string userid);
    }
}
