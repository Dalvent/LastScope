using UnityEngine;

namespace LastScope.Characters.Enemy.Trajectory
{
    public class DirectionalMoveTrajectory : IMoveTrajectory
    {
        private Quaternion _rotation;

        public DirectionalMoveTrajectory(Quaternion rotation)
        {
            _rotation = rotation;
        }

        public Vector3 NextMovement(EnemyMove enemyMove)
        {
            return _rotation * Vector3.up * (enemyMove.Speed * Time.deltaTime);
        }
    }
}