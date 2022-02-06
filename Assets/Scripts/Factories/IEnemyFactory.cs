using LastScope.Characters.Enemy;
using UnityEngine;

namespace LastScope.Factories
{
    public interface IEnemyFactory
    {
        GameObject CreateEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion);
    }
}