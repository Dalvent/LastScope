using LastScope.Logic;
using UnityEngine;

namespace LastScope.Characters.GameField
{
    public class GameFieldFacade : MonoBehaviour, IGameFieldFacade
    {
        public GameFieldMove Move;
        public DespawnArea DespawnArea;
        
        public bool IsOutOfMap(Vector2 point)
        {
            return DespawnArea.IsOutOfMap(point);
        }
    }
}