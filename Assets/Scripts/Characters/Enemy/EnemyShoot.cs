using LastScope.Services;
using LastScope.StaticData;
using Zenject;

namespace LastScope.Characters.Enemy
{
    public class EnemyShoot : Shoot
    {
        private IStaticDataService _staticDataService;
        public EnemyFacade EnemyFacade;

        public override CharacterType GetCharacterType()
            => CharacterType.Enemy;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
    
        public override ProjectileCustomisationStaticData GetCustomisation()
        {
            return _staticDataService.ForEnemy(EnemyFacade.EnemyType).Customisation;
        }
    }
}