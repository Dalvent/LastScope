using CodeBase.Services;
using DefaultNamespace.Factories.Pools;
using DefaultNamespace.StaticData;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
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