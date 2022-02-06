using LastScope.Characters;
using LastScope.StaticData;
using UnityEngine;

namespace LastScope.Factories
{
    public interface IProjectileFactory
    {
        GameObject CreateBullet(
            CharacterType characterType,
            float damage,
            float speed,
            ProjectileCustomisationStaticData customisation,
            Vector3 position, 
            Quaternion rotation);
    }
}