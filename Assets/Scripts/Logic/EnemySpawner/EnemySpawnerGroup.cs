using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemySpawnerGroup : MonoBehaviour
    {
        public List<EnemySpawnerMark> Spawners;

        private Stack<EnemySpawnerMark> _enemySpawnerMarks;

        public void Update()
        {
            // Sort to find spawner that exucte faster.
            var   OrderedByOccurrenceRate();

        }

        private Stack<EnemySpawnerMark> OrderedByOccurrenceRate()
        {
            return new Stack<EnemySpawnerMark>(Spawners
                .OrderBy(item => item.transform.position.y - item.SpawnWhenFieldIn));
        }
    }
}