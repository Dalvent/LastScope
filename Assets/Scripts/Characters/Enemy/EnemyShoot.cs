using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyShoot : Shoot
    {
        protected override int GetProjectileLayer()
        {
            return LayerMask.NameToLayer("EnemyProjectile");
        }
    }
}