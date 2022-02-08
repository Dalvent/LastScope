using LastScope.Additional;
using LastScope.Characters;
using UnityEditor;
using UnityEngine;

namespace LastScope.Editor
{
    public class DespawnOnOutOfMapGizmos
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected)]
        public static void OnDrawGizmo(DespawnArea despawnArea, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            AdditionalGizmos.DrawWireBorderCube(despawnArea.transform.position, despawnArea.Width, despawnArea.Height);
        }
    }
}