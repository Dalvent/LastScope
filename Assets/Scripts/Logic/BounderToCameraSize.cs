using UnityEngine;

namespace LastScope.Logic
{
    public class BounderToCameraSize : MonoBehaviour
    {
        public GameFieldBounder GameFieldBounder;
        public Camera Camera;
        
        private Vector2Int _lastSize;
        
        private Vector2Int _resolution;

        private void Awake()
        {
            _resolution = new Vector2Int(Screen.width, Screen.height);
        }
        
        public void Update()
        {
            if (_resolution.x != Screen.width || _resolution.y != Screen.height)
            {
                GetBounderSize();
                                
                _resolution = new Vector2Int(Screen.width, Screen.height);
            }
        }

        private void GetBounderSize()
        {
            var frustumHeight = 2.0f * 5 * Mathf.Tan(Camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        }
    }
}