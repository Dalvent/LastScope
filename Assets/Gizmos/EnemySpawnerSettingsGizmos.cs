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

            for (int i = 0; i < moveWay.Length - 1; i++)
            {
                /*
                be.startPoint = Handles.PositionHandle(be.startPoint, Quaternion.identity);
                be.endPoint = Handles.PositionHandle(be.endPoint, Quaternion.identity);
                be.startTangent = Handles.PositionHandle(be.startTangent, Quaternion.identity);
                be.endTangent = Handles.PositionHandle(be.endTangent, Quaternion.identity);

                Handles.DrawBezier(be.startPoint, be.endPoint, be.startTangent, be.endTangent, Color.red, null, 2f);
                Gizmos.DrawLine(((Vector2)spawner.transform.position) + moveWay[i].Position,
                    ((Vector2)spawner.transform.position) + moveWay[i + 1].Position);
            */
            }
        }
    }
}