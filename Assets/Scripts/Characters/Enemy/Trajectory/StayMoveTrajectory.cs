using UnityEngine;

namespace LastScope.Characters.Enemy.Trajectory
{
    public class StayMoveTrajectory : IMoveTrajectory
    {
        public Vector3 NextMovement(EnemyMove enemyMove)
        {
            return Vector3.zero;
        }
    }
}