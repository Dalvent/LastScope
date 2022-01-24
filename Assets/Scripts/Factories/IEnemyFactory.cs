using UnityEngine;
using Zenject;

namespace DefaultNamespace.Factories
{
    public interface IEnemyFactory
    {
        GameObject CreateEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion);
    }
}