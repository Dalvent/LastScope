using System;
using DefaultNamespace.StaticData;
using UnityEngine;

namespace DefaultNamespace.Factories
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