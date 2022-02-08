using System;
using LastScope.Extensions;
using LastScope.Logic;
using UnityEngine;
using Zenject;

namespace LastScope.Characters
{
    public class DespawnArea : MonoBehaviour
    {
        public float Width;
        public float Height;

        public bool IsOutOfMap(Vector2 point)
        {
            return transform.position.x + Width * 0.5f < point.x ||
                   transform.position.x - Width * 0.5f > point.x ||
                   transform.position.y + Height * 0.5f < point.y ||
                   transform.position.y - Height * 0.5f > point.y;
        }
    }
}