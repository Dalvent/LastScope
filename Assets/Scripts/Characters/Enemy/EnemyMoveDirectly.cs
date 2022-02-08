using UnityEngine;

namespace LastScope.Characters.Enemy
{
    public class EnemyMoveDirectly : MonoBehaviour, IEnemyMove
    {
        [SerializeField] private float _speed;
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
    
        // Update is called once per frame
        void Update()
        {
            transform.position += transform.rotation * Vector3.up * (Speed * Time.deltaTime);
        }

    }
}
