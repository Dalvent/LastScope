using UnityEngine;

namespace LastScope.Extensions
{
    public static class CameraPerspectiveExtensions
    {
        public static float PerspectiveLocalTop(this Camera camera, float distance)
        {
            return Mathf.Abs(distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad - camera.transform.rotation.x * 2));
        }
        
        public static float PerspectiveLocalBottom(this Camera camera, float distance)
        {
            float bottom = Mathf.Abs(distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad + camera.transform.rotation.x * 2));
            return -bottom;
        }
        
        public static float PerspectiveHeight(this Camera camera, float distance, out float yOffset)
        {
            float fullHeight = camera.PerspectiveLocalTop(distance) - camera.PerspectiveLocalBottom(distance);
            yOffset = fullHeight * 0.5f + camera.PerspectiveLocalBottom(distance);
            return fullHeight;
        }
    }
}