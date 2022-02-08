using System;
using LastScope.Additional;
using LastScope.Extensions;
using UnityEngine;

namespace LastScope.Logic
{
    // NOT DONE!!!
    public class GameFieldBounder : MonoBehaviour
    {
        [HideInInspector] [SerializeField] public float _height;
        public float TopMultiplayer = 1.0f;
        public float BottomMultiplayer = 1.0f;

        public float AngleOfTrapezoid = 90f;

        private bool _isInitialized;
        
        private void Start()
        {
            Camera gameplayCamera = Camera.main.GetGameplayCamera();
            _height = CalculateHeight(gameplayCamera, out float yOffset);
            transform.position = transform.position.AddY(yOffset);
            _isInitialized = true;
        }

        public float CalculateHeight(Camera camera, out float yOffset)
        {
            float cameraDistance = camera.transform.position.z - transform.position.z;
            
            float topHeightPart = Math.Abs(cameraDistance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad - camera.transform.rotation.x * 2));
            float bottomHeightPart = Math.Abs(cameraDistance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad + camera.transform.rotation.x * 2));
            float fullHeight = topHeightPart + bottomHeightPart;
            
            yOffset = fullHeight * 0.5f - bottomHeightPart;
            
            return fullHeight;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.12f, 0.72f, 0.12f, 1f);
            Camera gameplayCamera = Camera.main.GetGameplayCamera();
            
            var height = CalculateHeight(gameplayCamera, out float yOffset);

            if (_isInitialized)
                yOffset = 0;

            float angle = AngleOfTrapezoid * Mathf.Deg2Rad;

            float widthDifOfTrapezoid = Mathf.Atan(angle) * height;
            float topWidth = TopMultiplayer * Mathf.Abs(widthDifOfTrapezoid * gameplayCamera.aspect + widthDifOfTrapezoid);
            float bottomWidth = BottomMultiplayer * Mathf.Abs(widthDifOfTrapezoid * gameplayCamera.aspect - widthDifOfTrapezoid);

            Gizmos.color = Color.magenta;
            AdditionalGizmos.DrawWireBorderIsoscelesTrapezoid(transform.position.AddY(yOffset), topWidth, bottomWidth, height);
            
            
            Gizmos.color = new Color(0.5f, 1.0f, 0.5f);
            Gizmos.DrawLine(new Vector3(bottomWidth * 0.5f, -1000f, 0), new Vector3(bottomWidth * 0.5f, 1000f, 0));
            Gizmos.DrawLine(new Vector3(bottomWidth * -0.5f, -1000f, 0), new Vector3(bottomWidth * -0.5f, 1000f, 0));
            
            Gizmos.color = new Color(1.0f, 0.5f, 0.5f);
            Gizmos.DrawLine(new Vector3(topWidth * 0.5f, -1000f, 0), new Vector3(topWidth * 0.5f, 1000f, 0));
            Gizmos.DrawLine(new Vector3(topWidth * -0.5f, -1000f, 0), new Vector3(topWidth * -0.5f, 1000f, 0));
        }
    }
}