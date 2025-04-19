using Microsoft.EntityFrameworkCore;
using MizanGraduationProject.Data;
using MizanGraduationProject.Data.Models.OTP;

namespace MizanGraduationProject.Repositories.VerifyOtp
{
    public class VerifyOTPRepository : IVerifyOTPRepository
    {
        private readonly AppDbContext _dbContext;
        public VerifyOTPRepository(AppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task AddAsync(VerifyOTP t)
        {
            try
            {
                await _dbContext.VerifyOTPs.AddAsync(t);
                await SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            bool isVerifyOTPExists = await ExistsAsync(id);
            if (isVerifyOTPExists)
            {
                var otp = await GetByIdAsync(id);
                _dbContext.VerifyOTPs.Remove(otp);
                await SaveChangesAsync();
                return !await ExistsAsync(id);
            }
            return false;
        }

        public async Task<bool> DeleteByUserIdAsync(string userid)
        {
            bool isVerifyOTPExists = await ExistsByUserIdAsync(userid);
            if (isVerifyOTPExists)
            {
                var otp = await GetByUserIdAsync(userid);
                _dbContext.VerifyOTPs.Remove(otp);
                await SaveChangesAsync();
                return !await ExistsAsync(userid);
            }
            return false;
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _dbContext.VerifyOTPs.AnyAsync(t => t.ID == id);
        }

        public async Task<bool> ExistsByUserIdAsync(string userid)
        {
            return await _dbContext.VerifyOTPs.AnyAsync(t => t.UserID == userid);
        }

        public async Task<IEnumerable<VerifyOTP>> GetAllAsync()
        {
            return await _dbContext.VerifyOTPs.ToListAsync();
        }

        public async Task<VerifyOTP> GetByIdAsync(string id)
        {
            bool isVerifyOTPExists = await ExistsAsync(id);
            if (isVerifyOTPExists)
            {
                return (await _dbContext.VerifyOTPs.Where(e => e.ID == id).FirstOrDefaultAsync())!;
            }
            return null!;
        }

        public async Task<Data.Models.OTP.VerifyOTP> GetByUserIdAsync(string userid)
        {
            bool isVerifyOTPExists = await ExistsByUserIdAsync(userid);
            if (isVerifyOTPExists)
            {
                return (await _dbContext.VerifyOTPs.Where(e => e.UserID == userid).FirstOrDefaultAsync())!;
            }
            return null!;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> UpdateAsync(VerifyOTP t)
        {
            throw new NotImplementedException();
        }
    }
}
