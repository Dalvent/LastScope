using Zenject;

namespace LastScope.Characters.Enemy
{
    public class EnemyFacade : Poolable
    {
        public EnemyType EnemyType { get; set; }
        
        public Health Health;
        public EnemyMoveDirectly EnemyMoveDirectly;
        public EnemyShoot EnemyShoot; 
        
        public class Factory : PlaceholderFactory<EnemyFacade>
        {
        }
    }
}