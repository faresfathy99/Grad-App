
using Microsoft.EntityFrameworkCore;
using MizanGraduationProject.Data;

namespace MizanGraduationProject.Repositories.LoginOTP
{
    public class LoginOTPRepository : ILoginOTPRepository
    {
        private readonly AppDbContext _dbContext;
        public LoginOTPRepository(AppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task AddAsync(Data.Models.OTP.LoginOTP t)
        {
            try
            {
                await _dbContext.LoginOTPs.AddAsync(t);
                await SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            bool isLoginOTPExists = await ExistsAsync(id);
            if (isLoginOTPExists)
            {
                var otp = await GetByIdAsync(id);
                _dbContext.LoginOTPs.Remove(otp);
                await SaveChangesAsync();
                return !await ExistsAsync(id);
            }
            return false;
        }

        public async Task<bool> DeleteByUserIdAsync(string userid)
        {
            bool isLoginOTPExists = await ExistsByUserIdAsync(userid);
            if (isLoginOTPExists)
            {
                var otp = await GetByUserIdAsync(userid);
                _dbContext.LoginOTPs.Remove(otp);
                await SaveChangesAsync();
                return !await ExistsAsync(userid);
            }
            return false;
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _dbContext.LoginOTPs.AnyAsync(t => t.ID == id);
        }

        public async Task<bool> ExistsByUserIdAsync(string userid)
        {
            return await _dbContext.LoginOTPs.AnyAsync(t => t.UserID == userid);
        }

        public async Task<IEnumerable<Data.Models.OTP.LoginOTP>> GetAllAsync()
        {
            return await _dbContext.LoginOTPs.ToListAsync();
        }

        public async Task<Data.Models.OTP.LoginOTP> GetByIdAsync(string id)
        {
            bool isLoginOTPExists = await ExistsAsync(id);
            if (isLoginOTPExists)
            {
                return (await _dbContext.LoginOTPs.Where(e => e.ID == id).FirstOrDefaultAsync())!;
            }
            return null!;
        }

        public async Task<Data.Models.OTP.LoginOTP> GetByUserIdAsync(string userid)
        {
            bool isLoginOTPExists = await ExistsByUserIdAsync(userid);
            if (isLoginOTPExists)
            {
                return (await _dbContext.LoginOTPs.Where(e => e.UserID == userid).FirstOrDefaultAsync())!;
            }
            return null!;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> UpdateAsync(Data.Models.OTP.LoginOTP t)
        {
            throw new NotImplementedException();
        }
    }
}
