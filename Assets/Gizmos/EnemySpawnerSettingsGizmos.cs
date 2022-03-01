using LastScope.Extensions;
using LastScope.Logic.Spawner;
using UnityEditor;
using UnityEngine;

namespace LastScope.Editor
{
    public class EnemySpawnerSettingsGizmos
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected)]
        public static void OnDrawGizmo(EnemySpawner spawner, GizmoType gizmoType)
        {
            MoveWayPosition[] moveWay = spawner.SpawnerSettings.WayTrajectorySettings.MoveWayPositions;
            Vector3 spawnerPosition = spawner.transform.position;
            
            if (moveWay.Length > 0)
            {
                DrawWayLine(spawnerPosition,  Vector2.zero, moveWay[0].Position);
            }
            
            for (int i = 0; i < moveWay.Length - 1; i++)
            {
                DrawWayLine(spawnerPosition, moveWay[i].Position, moveWay[i + 1].Position);
            }
        }

        private static void DrawWayLine(Vector3 spawnerPosition, Vector2 start, Vector2 end) => 
            Gizmos.DrawLine(start.ToVector3() + spawnerPosition, end.ToVector3() + spawnerPosition);
    }
}