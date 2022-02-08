using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastScope
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class CameraFixedPerspectiveHeight : MonoBehaviour
    {
        public float horizontalFoV = 90.0f;

        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        // Update is called once per frame

        private void Update()
        {
            float halfWidth = Mathf.Tan(0.5f * horizontalFoV * Mathf.Deg2Rad);

            float halfHeight = halfWidth * Screen.height / Screen.width;

            float verticalFoV = 2.0f * Mathf.Atan(halfHeight) * Mathf.Rad2Deg;

            _camera.fieldOfView = verticalFoV;
        }
    }
}