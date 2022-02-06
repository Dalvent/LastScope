using UnityEngine;

namespace LastScope.Services.Input
{
    public interface IInputService
    {
        bool UseMove { get; }
        Vector2 MovePosition { get; }
    }
}