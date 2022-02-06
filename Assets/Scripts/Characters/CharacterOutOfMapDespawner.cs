using LastScope.Extensions;
using LastScope.Services.Game;
using UnityEngine;
using Zenject;

namespace LastScope.Characters
{
    public class CharacterOutOfMapDespawner : MonoBehaviour
    {
        private IGameFieldService _gameFieldService;
        public Poolable Despawn;

        [Inject]
        public void Construct(IGameFieldService gameFieldService)
        {
            _gameFieldService = gameFieldService;
        }

        private void Update()
        {
            if(_gameFieldService.DespawnArea.IsIn(Despawn.transform.position))
                return;
            
            Despawn.Dispose();
        }
    }
}