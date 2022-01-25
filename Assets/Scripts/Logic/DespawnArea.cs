using UnityEngine;

namespace DefaultNamespace.Logic
{
    public class DespawnArea : MonoBehaviour, ISquare
    {
        [SerializeField] private float _width;
        [SerializeField] private float _height;

        public float Width => _width;
        public float Height => _height;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0.5f, 0.5f, 0.05f);
            Gizmos.DrawCube(transform.position, new Vector3(Width, Height, 1));
        }
    }
}