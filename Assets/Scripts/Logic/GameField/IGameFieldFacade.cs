using UnityEngine;

namespace LastScope.Logic.GameField
{
    public interface IGameFieldFacade
    {
        float GetTop();
        float GetBottom();
        public Transform transform { get; }
        bool IsOutOfMap(Vector2 point);
    }
}