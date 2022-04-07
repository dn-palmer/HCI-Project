using BitWise.Data;
using BitWise.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitWise.Services
{
    public class AchievementsRepo : IAchievementsRepo
    {
        private BitWiseContext _db;

        public AchievementsRepo(BitWiseContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Trophy achievement)
        {
            if (achievement != null)
            {
                await _db.Trophies.AddAsync(achievement);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int achievementlId)
        {
            var achievement = await ReadAsync(achievementlId);

            _db.Trophies.Remove(achievement);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Trophy>> ReadAllAsync()
        {
            return await _db.Trophies.ToListAsync();
        }

        public async Task<Trophy> ReadAsync(int achievementId)
        {
            return await _db.Trophies.FirstOrDefaultAsync(a => a.Id == achievementId);
        }

        public async Task UpdateAsync(int achievementId, Trophy trophy)
        {
            var toUpdate = await ReadAsync(achievementId);

            if (trophy != null)
            {
                toUpdate.DateEarned = trophy.DateEarned;
                toUpdate.Description = trophy.Description;
                toUpdate.Name = trophy.Name;
                toUpdate.Image = trophy.Image;


                await _db.SaveChangesAsync();
            }
        }
    }
}
