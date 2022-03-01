using System;
using System.ComponentModel;
using LastScope.Characters.Enemy.Trajectory;

namespace LastScope.Logic.Spawner
{
    [Serializable]
    public class WayTrajectorySettings
    {
        public bool IgnoreDespawnWhileMove;
        public MoveWayPosition[] MoveWayPositions;
        public MoveTrajectoryType MoveOnEnd;
    }
}