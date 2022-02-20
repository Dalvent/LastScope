using System;
using UnityEngine;

namespace LastScope.Extensions
{
    public static class CameraOrthographicExtensions
    {
        public static Vector2 OrthographicSize(this Camera camera)
        {
            float height = 2 * camera.orthographicSize;
            float width = height * camera.aspect;
            return new Vector2(width, height);
        }
        
        public static float OrthographicHeight(this Camera camera)
        {
            float height = 2 * camera.orthographicSize;
            return height;
        }
    }
}