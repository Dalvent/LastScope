using System;
using System.Collections.Generic;
using LastScope.Extensions;
using LastScope.Logic.Spawner;
using UnityEngine;

namespace LastScope.Characters.Enemy.Trajectory
{
    public class WayMoveTrajectory : IMoveTrajectory
    {
        private readonly Transform _spawnerTransform;
        private readonly WayTrajectorySettings _wayTrajectorySettings;
        private readonly Queue<MoveWayPosition> _moveWayPositionsStack;

        public WayMoveTrajectory(Transform spawnerTransform, WayTrajectorySettings wayTrajectorySettings)
        {
            _wayTrajectorySettings = wayTrajectorySettings;
            _spawnerTransform = spawnerTransform;
            _moveWayPositionsStack = new Queue<MoveWayPosition>(wayTrajectorySettings.MoveWayPositions);
        }

        public Vector3 NextMovement(EnemyMove enemyMove)
        {
            MoveWayPosition moveWayPosition = _moveWayPositionsStack.Peek();

            Vector3 movementTarget = _spawnerTransform.position + moveWayPosition.Position.ToVector3();
            Vector3 result = Vector3.MoveTowards(enemyMove.transform.position,
                movementTarget,
                enemyMove.Speed * moveWayPosition.SpeedMultiplayer * Time.deltaTime) - enemyMove.transform.position;

            if ((enemyMove.transform.position + result) == movementTarget)
            {
                _moveWayPositionsStack.Dequeue();
            }
            
            if (_moveWayPositionsStack.Count == 0)
            {
                enemyMove.ChangeTrajectory(CreateNextTrajectory(enemyMove));
            }

            return result;
        }
        
        private IMoveTrajectory CreateNextTrajectory(EnemyMove enemyMove)
        {
            return _wayTrajectorySettings.MoveOnEnd switch
            {
                MoveTrajectoryType.Stay => new StayMoveTrajectory(),
                MoveTrajectoryType.Directional => new DirectionalMoveTrajectory(_spawnerTransform.rotation),
                _ => throw new ArgumentOutOfRangeException(nameof(SpawnerSettings.MovementType), _wayTrajectorySettings.MoveOnEnd, null)
            };
        }
    }
}