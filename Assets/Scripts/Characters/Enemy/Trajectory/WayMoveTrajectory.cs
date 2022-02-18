using System;
using LastScope.Logic.Spawner;
using UnityEngine;

namespace LastScope.Characters.Enemy.Trajectory
{
    public class WayMoveTrajectory : IMoveTrajectory
    {
        private readonly WayTrajectorySettings _wayTrajectorySettings;

        public WayMoveTrajectory(WayTrajectorySettings wayTrajectorySettings)
        {
            _wayTrajectorySettings = wayTrajectorySettings;
        }

        public Vector3 NextMovement(EnemyMove enemyMove)
        {
            throw new NotImplementedException();
        }
    }
}