using LastScope.Characters.Enemy;
using UnityEngine;

namespace LastScope.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy/Default")]    
    public class EnemyStaticData : ScriptableObject
    {
        public string Name;

        public BehaviorType BehaviorType;
        
        public float MaxHealth;
        public float Damage;
        public float Speed;
        [Range(0f, 10f)]
        public float ReloadTime;
        public float BulletSpeed;
        
        public GameObject Prefab;
    }
}