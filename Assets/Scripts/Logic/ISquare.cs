using UnityEngine;

namespace DefaultNamespace.Logic
{
    public interface ISquare
    {
        public Transform transform { get; }
        public float Width { get; }
        public float Height { get; }
    }
}