using UnityEngine;

namespace CodeBase.Services
{
    public class GameFieldService : IGameFieldService
    {
        private readonly GameFieldBounder _bounder;

        public GameFieldService(GameFieldBounder bounder)
        {
            _bounder = bounder;
        }

        public float HalfFieldWidth => _bounder.HalfFieldWidth;
        public float HalfFieldHeight => _bounder.HalfFieldHeight;
        
        public Vector3 InFieldRange(Vector3 position, float width, float height)
        {
            return _bounder.InFieldRange(position, width, height);
        }

        public Transform Transform => _bounder.transform;
    }
}