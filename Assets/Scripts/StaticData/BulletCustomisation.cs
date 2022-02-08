using UnityEngine;

namespace LastScope.StaticData
{
    [CreateAssetMenu(fileName = "BulletCustomisation", menuName = "StaticData/Projectile")]    
    public class BulletCustomisation : ScriptableObject
    {
        public float Width = 1;
        public float Height = 1;

        public Material Material;
    }
}