using System.Reflection.Emit;
using Cinemachine;
using UnityEngine;

namespace DefaultNamespace
{
    public class CinemachineFieldConfiner : CinemachineExtension
    {
        public GameFieldBounder gameFieldBounder;

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (gameFieldBounder == null || stage != CinemachineCore.Stage.Body) 
                return;
            
            float cameraHeight = state.Lens.OrthographicSize * 2;
            float cameraWidth = cameraHeight * state.Lens.Aspect;

            Vector3 finalPosition = gameFieldBounder.InFieldRange(state.RawPosition, cameraWidth, cameraHeight);
            
            if (cameraWidth > gameFieldBounder.HalfFieldWidth * 2)
            {
                finalPosition.x = gameFieldBounder.transform.position.x;
            }
            if(cameraHeight > gameFieldBounder.HalfFieldHeight * 2)
            {
                finalPosition.y = gameFieldBounder.transform.position.y;
            }
            
            state.RawPosition = finalPosition;
        }
    }
}