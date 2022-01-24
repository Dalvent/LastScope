
using UnityEngine;

namespace CodeBase.Services
{
    public interface IGameFieldService
    {
        public float HalfFieldWidth { get; }
        public float HalfFieldHeight { get; }
        Vector3 InFieldRange(Vector3 position, float width, float height);
        Transform Transform { get; }
    }
}