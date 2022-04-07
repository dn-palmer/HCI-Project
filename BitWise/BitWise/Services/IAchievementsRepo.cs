using BitWise.Models.Entities;

namespace BitWise.Services
{
    public interface IAchievementsRepo
    {
       
        
            Task<Trophy> ReadAsync(int achievementId);
            Task<IEnumerable<Trophy>> ReadAllAsync();
            Task CreateAsync(Trophy achievement);
            Task UpdateAsync(int achievementId, Trophy trophy);
            Task DeleteAsync(int achievementlId);
        
    }
}
