using UnityEngine;

namespace LastScope.Characters.Shoot
{
    public class ShootGunBulletShoot : BulletShoot
    {
        public int BulletCount = 1;
        public float Angle = 0.1f;

        public override void Upgrade(int power = 1)
        {
            BulletCount++;
            base.Upgrade(power);
        }

        protected override void CreateProjectile(Vector3 position, Quaternion rotation)
        {
            if(BulletCount == 0)
                return;

            if (BulletCount == 1)
            {
                base.CreateProjectile(position, rotation);
                return;
            }
                
            float fullAngle = Angle * (BulletCount - 1);
            for (int i = 0; i < BulletCount; i++)
            {
                float bulletAngle = fullAngle * -0.5f + Angle * i;
                base.CreateProjectile(position, Quaternion.AngleAxis(bulletAngle, Vector3.forward));
            }
        }
    }
}