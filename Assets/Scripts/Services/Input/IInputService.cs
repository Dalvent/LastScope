using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    {
        bool UseMove { get; }
        Vector2 MovePosition { get; }
    }
}