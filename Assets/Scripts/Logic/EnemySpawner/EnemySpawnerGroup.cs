using System.Collections.Generic;
using System.Linq;
using LastScope.Extensions;
using LastScope.Factories;
using LastScope.Services.Game;
using UnityEngine;
using Zenject;

namespace LastScope.Logic.EnemySpawner
{
    public class EnemySpawnerGroup : MonoBehaviour
    {
        public List<EnemySpawnerMark> Spawners;

        private Queue<EnemySpawnerMark> _spawnersByOccurrenceRate;
        private IGameFieldService _gameFieldService;
        private IEnemyFactory _enemyFactory;

        [Inject]
        public void Constructor(IGameFieldService gameFieldService, IEnemyFactory enemyFactory)
        {
            _gameFieldService = gameFieldService;
            _enemyFactory = enemyFactory;
        }

        public void Awake()
        {
            // Sort to find spawner that exucte faster.
            _spawnersByOccurrenceRate = OrderedByOccurrenceRate();
        }

        private void Update()
        {
            while (_spawnersByOccurrenceRate.Count != 0)
            {
                EnemySpawnerMark nearestSpawner = _spawnersByOccurrenceRate.Peek();
                if (CanSpawnOn(nearestSpawner))
                {
                    SpawnOn(nearestSpawner);
                    _spawnersByOccurrenceRate.Dequeue();
                }
                else
                {
                    break;
                }
            }
        }

        private bool CanSpawnOn(EnemySpawnerMark spawnerMark)
        {
            return spawnerMark.transform.position.y - spawnerMark.SpawnWhenFieldIn <= _gameFieldService.Bounder.Top();
        }

        private void SpawnOn(EnemySpawnerMark spawnerMark)
        {
            _enemyFactory.CreateEnemy(spawnerMark.EnemyType, spawnerMark.transform.position, spawnerMark.transform.rotation);
;        }

        private Queue<EnemySpawnerMark> OrderedByOccurrenceRate()
        {
            return new Queue<EnemySpawnerMark>(Spawners
                .OrderBy(item => item.transform.position.y - item.SpawnWhenFieldIn));
        }
    }
}