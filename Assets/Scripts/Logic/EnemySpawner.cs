using System;
using LastScope.Factories;
using LastScope.StaticData;
using UnityEngine;
using Zenject;

namespace LastScope.Logic
{
    public class EnemySpawner : MonoBehaviour
    {
        public TriggerObserver2D TriggerObserver2D;
        public EnemyStaticData EnemyStaticData;
        private IGameFactory _gameFactory;

        private bool _isExecuted = false;
        public bool IsExecuted => _isExecuted;
        
        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
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
            if(_isExecuted)
                return;
            
            _gameFactory.CreateEnemy(EnemyStaticData, transform.position, transform.rotation);
            _isExecuted = true;
            TriggerObserver2D.enabled = false;
        }
    }
}