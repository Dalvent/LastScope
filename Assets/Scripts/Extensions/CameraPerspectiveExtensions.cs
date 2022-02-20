using UnityEngine;

namespace LastScope.Extensions
{
    public static class CameraPerspectiveExtensions
    {
        public static float PerspectiveLocalTop(this Camera camera, float distance)
        {
            float top = Mathf.Abs(distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad - camera.transform.rotation.x * 2));
            return top;
        }
        
        public static float PerspectiveLocalBottom(this Camera camera, float distance)
        {
            float bottom = Mathf.Abs(distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad + camera.transform.rotation.x * 2));
            return -bottom;
        }
        
        public static float PerspectiveHeight(this Camera camera, float distance, out float yOffset)
        {
            float top = camera.PerspectiveLocalTop(distance);
            float bottom = camera.PerspectiveLocalBottom(distance);
            
            float fullHeight = top - bottom;
            yOffset = fullHeight * 0.5f + bottom;
            return fullHeight;
        }
    }
}