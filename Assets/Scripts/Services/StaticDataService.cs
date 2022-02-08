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

        public void Load()
        {
            _player = Resources.Load<PlayerStaticData>("StaticData/Player");
        }

        public PlayerStaticData Player => _player;
    }
}