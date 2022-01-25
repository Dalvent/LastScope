using UnityEngine;

namespace DefaultNamespace.StaticData
{
    [CreateAssetMenu(fileName = "ProjectileCustomisation", menuName = "StaticData/Projectile/Customisation")]    
    public class ProjectileCustomisationStaticData : ScriptableObject
    {
        public float Width = 1;
        public float Height = 1;

        public Material Material;
    }
}