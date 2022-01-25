using System;
using DefaultNamespace.Logic;
using UnityEngine;

namespace Extensions
{
    public static class SquareExtensions
    {
        public static float HalfHeight(this ISquare square)
            => square.Height * 0.5f;
        
        public static float HalfWidth(this ISquare square)
            => square.Width * 0.5f;
        
        public static float Top(this ISquare square)
        {
            return square.transform.position.y + square.HalfHeight();
        }
        
        public static float Bottom(this ISquare square)
        {
            return square.transform.position.y - square.HalfHeight();
        }
        
        public static float Right(this ISquare square)
        {
            return square.transform.position.x + square.HalfWidth();
        }
        
        public static float Left(this ISquare square)
        {
            return square.transform.position.x - square.HalfWidth();
        }
        
        public static Vector3 InSquareRange(this ISquare square, Vector3 point, float itemWidth, float itemHeight)
        {
            float halfItemWidth = itemWidth * 0.5f;
            float halfItemHeight = itemHeight * 0.5f;
            
            return new Vector3(
                InRange(point.x, square.Left() + halfItemWidth, square.Right() - halfItemWidth), 
                InRange(point.y, square.Bottom() + halfItemHeight, square.Top() - halfItemHeight),
                point.z);
        }

        public static bool IsIn(this ISquare square, Vector2 point)
        {
            return square.Top() >= point.y
                && square.Bottom() <= point.y
                && square.Right() >= point.x
                && square.Left() <= point.x;
        }

        private static float InRange(float value, float min, float max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        private static bool IsInRange(float value, float min, float max)
        {
            return value >= min && value <= max;
        }
    }
}