using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Levels.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Levels.NS
{
    public class LevelsService : ILevelsService
    {
        private readonly ParaglidingClubContext _paraContext;

        public LevelsService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentOutOfRangeException(nameof(paraContext));
        }
        
        public async Task<LevelDto> GetLevelAsync(int id)
        {
            var level = await _paraContext.Levels
                .AsNoTracking()
                .Select(l => new LevelDto
                {
                    LevelID = l.ID,
                    Name = l.Name,
                    Skill = l.Skill,
                    IsActive = l.IsActive
                })
                .FirstOrDefaultAsync(l => l.LevelID == id);

            return level;
        }
        public async Task<IReadOnlyCollection<LevelDto>> GetAllLevelsAsync()
        {
            var levels = _paraContext.Levels
                .AsNoTracking()
                .Select(l => new LevelDto
                {
                    LevelID = l.ID,
                    Name = l.Name,
                    Skill = l.Skill,
                    IsActive = l.IsActive
                });

            return await levels.ToListAsync();
        }

        public async Task<bool?> UpdateLevelAsync(int LevelId, LevelPatchDto patchDto)
        {
            var levelToUpdate = await _paraContext.Levels
                .FirstOrDefaultAsync(p => p.ID == LevelId);

            if (levelToUpdate == null) return null;

            levelToUpdate.Name = patchDto.Name;
            levelToUpdate.Skill = patchDto.skill;

            return await _paraContext.SaveChangesAsync() > 0;

        }

        public async Task<LevelPatchDto>GetLevelToPatchAsync(int LevelId)
        {
            return await _paraContext.Levels

               .Where(p => p.ID == LevelId)
               .Select(p => new LevelPatchDto
               {
                   Name = p.Name,
                   skill = p.Skill
               })
               .FirstOrDefaultAsync();

        }
    }
}
