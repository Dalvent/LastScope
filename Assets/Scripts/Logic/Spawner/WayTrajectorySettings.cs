using System;
using LastScope.Characters.Enemy.Trajectory;

namespace LastScope.Logic.Spawner
{
    [Serializable]
    public class WayTrajectorySettings
    {
        public MoveWayPosition[] MoveWayPositions;
        public MoveTrajectoryType MoveOnEnd;
    }
}