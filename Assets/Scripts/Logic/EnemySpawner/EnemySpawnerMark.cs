using LastScope.Additional;
using LastScope.Characters.Enemy;
using LastScope.Extensions;
using UnityEngine;

namespace LastScope.Logic.EnemySpawner
{
    public class EnemySpawnerMark : MonoBehaviour
    {
        public EnemyType EnemyType;
        public float SpawnWhenFieldIn = 1;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0.2f, 0.2f, 0.4f);
            Gizmos.DrawSphere(transform.position, 0.3f);

            Gizmos.DrawCube(transform.position.AddY(SpawnWhenFieldIn * -0.5f), new Vector3(0.3f, SpawnWhenFieldIn, 0.3f));

            Gizmos.color = new Color(0.2f, 0.2f, 1f, 0.4f);
            AdditionalGizmos.DrawCube(transform.position, transform.rotation, Vector3.up * 0.5f, new Vector3(0.3f, 1f, 0.3f));
        }
    }
}