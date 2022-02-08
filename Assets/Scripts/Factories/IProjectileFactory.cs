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
            BulletCustomisation customisation,
            Vector3 position, 
            Quaternion rotation);
    }
}