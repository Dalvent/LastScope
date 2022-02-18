using System;
using System.Collections.Generic;
using LastScope.Logic.Spawner;
using LastScope.Services;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace LastScope.Characters.Enemy
{
    public class EnemyTurning : MonoBehaviour
    {
        public EnemyMove EnemyMove;
        
        public LookAtType LookAtType;
        private IPlayerService _playerService;

        [Inject]
        public void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        private void OnEnable()
        {
            EnemyMove.DirectionChanged += OnDirectionChanged;
        }

        private void OnDisable()
        {
            EnemyMove.DirectionChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector2 obj)
        {
            if(LookAtType != LookAtType.MoveDirection)
                return;

            float angle = Mathf.Atan2(-obj.x, obj.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void Update()
        {
            if (LookAtType != LookAtType.Player)
                return;
            
            if(_playerService.IsDead)
                return;
            
            Vector3 diff = _playerService.Transform.position - transform.position;
            diff.Normalize();
 
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
}