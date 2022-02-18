using UnityEngine;

namespace LastScope.Characters.Enemy.Trajectory
{
    public interface IMoveTrajectory
    {
        Vector3 NextMovement(EnemyMove enemyMove);
    }
}