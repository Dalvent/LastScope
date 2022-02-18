using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using LastScope.Characters.Enemy.Trajectory;
using UnityEngine;

namespace LastScope.Characters.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private IMoveTrajectory _moveTrajectory = new StayMoveTrajectory();

        private Vector3 _lastDirection;
        
        public event Action<Vector2> DirectionChanged;
        
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public void ChangeTrajectory(IMoveTrajectory moveTrajectory)
        {
            _moveTrajectory = moveTrajectory;
        }
    
        // Update is called once per frame
        private void Update()
        {
            Vector3 movement = _moveTrajectory.NextMovement(this);
            transform.position += movement;

            Vector3 newDirection = movement.normalized;
            if (newDirection != _lastDirection)
            {
                _lastDirection = newDirection;
                DirectionChanged?.Invoke(newDirection);
            }
                
            //transform.position += transform.rotation * Vector3.up * (Speed * Time.deltaTime);
        }

    }
}
