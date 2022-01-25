using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Editor
{
    
    [CustomEditor(typeof(EnemySpawnerMark))]
    public class EnemySpawnerMarkEditor : UnityEditor.Editor
    {
        public void OnEnable()
        {
            
            EnemySpawnerMark enemySpawnerMark = (EnemySpawnerMark)target;
            EnemySpawnerGroup enemySpawnerGroup = enemySpawnerMark.transform.GetComponentInParent<EnemySpawnerGroup>();

            if (!enemySpawnerGroup.Spawners.Contains(enemySpawnerMark))
            {
                enemySpawnerGroup.Spawners.Add(enemySpawnerMark);
                EditorUtility.SetDirty(enemySpawnerGroup);
            }
        }
    }
}