using LastScope.Characters.Enemy;
using LastScope.StaticData;

namespace LastScope.Services
{
    public interface IStaticDataService
    {
        void Load();
        EnemyStaticData ForEnemy(EnemyType type);
        PlayerStaticData Player { get; }
    }
}