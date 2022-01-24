using System;
using Extensions;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
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
            var defaultMatrix = Gizmos.matrix;
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Gizmos.matrix = rotationMatrix;
            Gizmos.DrawCube( Vector3.down * 0.5f, new Vector3(0.3f, 1f, 0.3f));
            Gizmos.matrix = defaultMatrix;
        }
    }
}