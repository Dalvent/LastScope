using UnityEngine;
using Zenject;

namespace LastScope.Characters.Enemy
{
    public class EnemyFacade : MonoBehaviour
    {
        public Health Health;
        public EnemyMoveDirectly EnemyMoveDirectly;
        public BulletShoot enemyBulletShoot;
    }
}