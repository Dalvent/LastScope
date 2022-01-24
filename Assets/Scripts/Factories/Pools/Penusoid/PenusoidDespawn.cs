using UnityEngine;
using Zenject;

namespace DefaultNamespace.Factories.Pools
{
    public class PenusoidDespawn : PoolDespawn
    {
        private Pool _penusoidEnemyPool;

        [Inject]
        public void Constructor(Pool penusoidEnemyPool)
        {
            _penusoidEnemyPool = penusoidEnemyPool;
        }
        
        public override void Despawn()
        {
            _penusoidEnemyPool.Despawn(this);
        }
        
        public class Pool : MonoMemoryPool<Vector3, Quaternion, PenusoidDespawn>
        {
        }
    }
}