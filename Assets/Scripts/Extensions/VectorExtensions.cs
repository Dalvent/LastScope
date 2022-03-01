using UnityEngine;

namespace LastScope.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 SetX(this Vector3 vector, float x)
        {
            vector.x = x;
            return vector;
        }
        public static Vector3 SetY(this Vector3 vector, float y)
        {
            vector.y = y;
            return vector;
        }
        
        public static Vector3 AddX(this Vector3 vector, float value)
        {
            vector.x += value;
            return vector;
        }
        public static Vector3 AddY(this Vector3 vector, float value)
        {
            vector.y += value;
            return vector;
        }
        
        public static Vector2 SetX(this Vector2 vector, float x)
        {
            vector.x = x;
            return vector;
        }
        public static Vector2 SetY(this Vector2 vector, float y)
        {
            vector.y = y;
            return vector;
        }
        
        public static Vector3 ToVector3(this Vector2 vector) =>
            vector;

        public static Vector3 SetZ(this Vector2 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }
        
        public static Vector2 AddX(this Vector2 vector, float value)
        {
            vector.x += value;
            return vector;
        }
        public static Vector2 AddY(this Vector2 vector, float value)
        {
            vector.y += value;
            return vector;
        }
    }
}