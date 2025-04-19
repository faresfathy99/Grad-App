using MizanGraduationProject.Repositories.Crud;

namespace MizanGraduationProject.Repositories.LoginOTP
{
    public interface ILoginOTPRepository : ICrud<Data.Models.OTP.LoginOTP>
    {
        public Task<Data.Models.OTP.LoginOTP> GetByUserIdAsync(string userid);
        public Task<bool> DeleteByUserIdAsync(string userid);
        public Task<bool> ExistsByUserIdAsync(string userid);
    }
}
