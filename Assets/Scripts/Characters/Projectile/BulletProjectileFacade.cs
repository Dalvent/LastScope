using System;
using UnityEngine;
using Zenject;

namespace LastScope.Characters.Projectile
{
    public class BulletProjectileFacade : Poolable
    {
        private const string PlayerProjectileLayer = "PlayerProjectile";
        private const string EnemyProjectileLayer = "EnemyProjectile";
        
        [SerializeField] private MeshRenderer _mesh;
        public BulletProjectile BulletProjectile;
        
        private CharacterType _ownerType;
        public CharacterType OwnerType
        {
            get => _ownerType;
            set
            {
                if(_ownerType == value)
                    return;

                _ownerType = value;
                gameObject.layer = GetOwnerProjectileLayer(_ownerType);
                foreach (Transform transform  in gameObject.transform)
                {
                    transform.gameObject.layer = GetOwnerProjectileLayer(_ownerType);
                }
            }
        }

        private int GetOwnerProjectileLayer(CharacterType characterType)
        {
            return characterType switch
            {
                CharacterType.Player => LayerMask.NameToLayer(PlayerProjectileLayer),
                CharacterType.Enemy => LayerMask.NameToLayer(EnemyProjectileLayer),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        public void ChangeMaterial(Material material)
        {
            _mesh.material = material;
        }
        
        public class Factory : PlaceholderFactory<BulletProjectileFacade>
        {
        }
    }
}