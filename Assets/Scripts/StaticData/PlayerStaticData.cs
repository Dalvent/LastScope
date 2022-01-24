using UnityEngine;

namespace DefaultNamespace.StaticData
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/Player")]    
    public class PlayerStaticData : ScriptableObject
    {
        public float MaxHealth;
        public float Damage;
        public float Speed;
        
        [Range(0f, 10f)]
        public float ReloadTime;
    }
}