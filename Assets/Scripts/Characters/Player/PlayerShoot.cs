using LastScope.Services;
using LastScope.StaticData;
using Zenject;

namespace LastScope.Characters.Player
{
    public class PlayerShoot : Shoot
    {
        private IStaticDataService _staticDataService;

        public override CharacterType GetCharacterType()
            => CharacterType.Player;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
    
        public override ProjectileCustomisationStaticData GetCustomisation()
        {
            return _staticDataService.Player.Customisation;
        }
    }
}