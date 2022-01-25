using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Editor
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