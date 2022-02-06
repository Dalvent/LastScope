using System.Linq;
using LastScope.Logic.EnemySpawner;
using UnityEditor;
using UnityEngine;

namespace LastScope.Editor
{
    [CustomEditor(typeof(EnemySpawnerGroup))]
    public class EnemySpawnerGroupEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EnemySpawnerGroup enemySpawnerGroup = (EnemySpawnerGroup)target;
            

            if (GUILayout.Button("Collect"))
            {
                var spawners = enemySpawnerGroup
                    .transform
                    .GetComponentsInChildren<EnemySpawnerMark>()
                    .ToList();
                
                enemySpawnerGroup.Spawners = spawners;
                EditorUtility.SetDirty(target);
            }
        }
    }
}