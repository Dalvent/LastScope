using System.Reflection.Emit;
using Cinemachine;
using Extensions;
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

            Vector3 finalPosition = gameFieldBounder.InSquareRange(state.RawPosition, cameraWidth, cameraHeight);
            
            if (cameraWidth > gameFieldBounder.Width)
            {
                finalPosition.x = gameFieldBounder.transform.position.x;
            }
            if(cameraHeight > gameFieldBounder.Height)
            {
                finalPosition.y = gameFieldBounder.transform.position.y;
            }
            
            state.RawPosition = finalPosition;
        }
    }
}