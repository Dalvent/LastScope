using System;
using DefaultNamespace.Factories.Pools;
using UnityEngine;

namespace DefaultNamespace.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly PenusoidDespawn.Pool _penusoidEnemyPool;
        
        public EnemyFactory(PenusoidDespawn.Pool penusoidEnemyPool)
        {
            _penusoidEnemyPool = penusoidEnemyPool;
        }
        
        public GameObject CreateEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion)
        {
            switch (enemyType)
            {
                case EnemyType.Penisoid:
                    return CreatePenisoid(position, quaternion);
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
            }
        }

        private GameObject CreatePenisoid(Vector3 position, Quaternion quaternion)
        {
            return _penusoidEnemyPool.Spawn(position, quaternion).gameObject;
        }
    }
}