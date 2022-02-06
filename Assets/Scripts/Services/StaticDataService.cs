using System.Collections.Generic;
using System.Linq;
using LastScope.Characters.Enemy;
using LastScope.StaticData;
using UnityEngine;

namespace LastScope.Services
{
    public class StaticDataService : IStaticDataService
    {
        private PlayerStaticData _player;
        private Dictionary<EnemyType, EnemyStaticData> _enemies;

        public void Load()
        {
            _player = Resources.Load<PlayerStaticData>("StaticData/Player");
            _enemies = Resources.LoadAll<EnemyStaticData>("StaticData/Enemies")
                .ToDictionary(x => x.EnemyType, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyType type) 
            => _enemies.TryGetValue(type, out EnemyStaticData staticData) 
                ? staticData 
                : null;

        public PlayerStaticData Player => _player;
    }
}