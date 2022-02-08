using UnityEngine;

namespace LastScope.Characters.GameField
{
    public interface IGameFieldFacade
    {
        public Transform transform { get; }

        bool IsOutOfMap(Vector2 point);
    }
}