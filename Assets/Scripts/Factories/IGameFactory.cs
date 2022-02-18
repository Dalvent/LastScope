using LastScope.StaticData;
using UnityEngine;

namespace LastScope.Factories
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(Transform parent);
        GameObject CreateEnemy(EnemyStaticData enemyStaticData, Vector3 position, Quaternion quaternion, Transform root);
    }
}