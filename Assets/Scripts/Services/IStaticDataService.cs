using DefaultNamespace;
using DefaultNamespace.StaticData;

namespace CodeBase.Services
{
    public interface IStaticDataService
    {
        void Load();
        EnemyStaticData ForEnemy(EnemyType type);
        PlayerStaticData Player { get; }
    }
}