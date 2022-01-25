using UnityEngine;

namespace DefaultNamespace.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy/Default")]    
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyType EnemyType;
        public float MaxHealth;
        public float Damage;
        public float Speed;
        [Range(0f, 10f)]
        public float ReloadTime;
        public float BulletSpeed;

        public ProjectileCustomisationStaticData Customisation;

        public GameObject Prefab;
    }
}