using ParaglidingProject.SL.Core.Levels.NS.TransfertObjects;
using ParaglidingProject.Models;

namespace ParaglidingProject.SL.Core.Levels.NS.MapperProfiles
{
    public static class LevelMapping
    {
        public static LevelDto MapLevelDto(this Level level)
        {
            var levelDto = new LevelDto
            {
                LevelID = level.ID,
                Name = level.Name,
                Skill = level.Skill,
                IsActive = level.IsActive
            };

            return levelDto;
        }
    }
}
