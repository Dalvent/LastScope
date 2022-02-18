using System;
using LastScope.Characters.Enemy;
using LastScope.Characters.Enemy.Trajectory;

namespace LastScope.Logic.Spawner
{
    [Serializable]
    public class SpawnerSettings
    {
        public bool SpawnInGameField;
        public MoveTrajectoryType MovementType;
        public LookAtType LookAtType;

        public WayTrajectorySettings WayTrajectorySettings;
    }
}