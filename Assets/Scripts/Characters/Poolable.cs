using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Factories.Pools
{
    public abstract class Poolable : MonoBehaviour, IPoolable<IMemoryPool>
    {
        private IMemoryPool _pool;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }
    }
}