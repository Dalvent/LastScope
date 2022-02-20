using System;
using LastScope.Characters.Enemy;
using LastScope.Characters.Enemy.Trajectory;
using LastScope.Factories;
using LastScope.Logic.GameField;
using LastScope.StaticData;
using UnityEngine;
using Zenject;

namespace LastScope.Logic.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        public TriggerObserver2D TriggerObserver2D;
        public EnemyStaticData EnemyStaticData;
        public SpawnerSettings SpawnerSettings;

        private IGameFactory _gameFactory;
        private IGameFieldFacade _gameFieldFacade;

        private bool _isExecuted = false;
        public bool IsExecuted => _isExecuted;

        [Inject]
        public void Construct(IGameFactory gameFactory, IGameFieldFacade gameFieldFacade)
        {
            _gameFactory = gameFactory;
            _gameFieldFacade = gameFieldFacade;
        }

        public void OnEnable()
        {
            TriggerObserver2D.TriggerEnter += SpawnEnemy;
        }

        public void OnDisable()
        {
            TriggerObserver2D.TriggerExit -= SpawnEnemy;
        }

        private void SpawnEnemy(Collider2D obj)
        {
            if (_isExecuted)
                return;

            GameObject enemy = CreateEnemy();

            var move = enemy.GetComponent<EnemyMove>();
            move.ChangeTrajectory(CreateTrajectory());
            
            var enemyTurning = enemy.GetComponent<EnemyTurning>();
            enemyTurning.LookAtType = SpawnerSettings.LookAtType;

            _isExecuted = true;
            TriggerObserver2D.enabled = false;
        }

        private IMoveTrajectory CreateTrajectory()
        {
            return SpawnerSettings.MovementType switch
            {
                MoveTrajectoryType.Stay => new StayMoveTrajectory(),
                MoveTrajectoryType.Directional => new DirectionalMoveTrajectory(transform.rotation),
                MoveTrajectoryType.Way => new WayMoveTrajectory(SpawnerSettings.WayTrajectorySettings),
                _ => throw new ArgumentOutOfRangeException(nameof(SpawnerSettings.MovementType), SpawnerSettings.MovementType, null)
            };
        }
        
        private GameObject CreateEnemy()
        {
            Transform enemyTransformRoot = null;
            if (SpawnerSettings.SpawnInGameField)
            {
                enemyTransformRoot = _gameFieldFacade.transform;
            }

            GameObject enemy = _gameFactory.CreateEnemy(EnemyStaticData, transform.position, transform.rotation, enemyTransformRoot);
            return enemy;
        }
    }
}