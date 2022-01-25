using DefaultNamespace.Logic;
using UnityEngine;

namespace CodeBase.Services
{
    public class GameFieldService : IGameFieldService
    {
        private readonly GameFieldBounder _bounder;
        private readonly DespawnArea _despawnArea;

        public GameFieldService( GameFieldBounder bounder, DespawnArea despawnArea)
        {
            _bounder = bounder;
            _despawnArea = despawnArea;
        }

        public ISquare Bounder => _bounder;
        public ISquare DespawnArea => _despawnArea;
    }
}