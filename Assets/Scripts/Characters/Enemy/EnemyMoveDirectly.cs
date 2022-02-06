using UnityEngine;

namespace LastScope.Characters.Enemy
{
    public class EnemyMoveDirectly : MonoBehaviour
    {
        public float Speed;
    
        // Update is called once per frame
        void Update()
        {
            transform.position += transform.rotation * Vector3.up * (Speed * Time.deltaTime);
        }
    }
}
