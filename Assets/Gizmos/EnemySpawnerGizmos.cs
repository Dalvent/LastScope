using LastScope.Additional;
using LastScope.Logic;
using UnityEditor;
using UnityEngine;

namespace LastScope.Editor
{
    public class EnemySpawnerGizmos
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.Active | GizmoType.NonSelected)]
        public static void OnDrawGizmo(EnemySpawner spawner, GizmoType gizmoType)
        {
            return;
            Gizmos.color = spawner.IsExecuted ? Color.gray : Color.green;
            MeshFilter[] meshFilters = spawner.EnemyStaticData.Prefab.GetComponentsInChildren<MeshFilter>();
            
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(spawner.transform.position, spawner.transform.rotation, spawner.transform.lossyScale);
            Matrix4x4 defaultMatrix = Gizmos.matrix;
            Gizmos.matrix = rotationMatrix;
            foreach (var meshFilter in meshFilters)
            {
                Gizmos.DrawWireMesh(meshFilter.sharedMesh,
                    meshFilter.transform.position,
                    meshFilter.transform.rotation,
                    meshFilter.transform.lossyScale);
            }

            Gizmos.matrix = defaultMatrix;
            
        }
    }
}