using UnityEngine;

namespace LastScope.CameraLogic
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class CameraFixedOrthographicHeight : MonoBehaviour
    {
        public float sceneWidth = 10;

        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }


        // Update is called once per frame

        private void Update()
        {
            float unitsPerPixel = sceneWidth / Screen.width;

            float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

            _camera.orthographicSize = desiredHalfHeight;
        }
    }
}