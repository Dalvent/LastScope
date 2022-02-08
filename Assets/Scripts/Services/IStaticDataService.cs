using LastScope.Characters.Enemy;
using LastScope.StaticData;

namespace LastScope.Services
{
    public interface IStaticDataService
    {
        void Load();
        PlayerStaticData Player { get; }
    }
}