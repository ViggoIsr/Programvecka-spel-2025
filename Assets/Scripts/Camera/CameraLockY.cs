using UnityEngine;
using Cinemachine;

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Y coordinate in Unity 2D.
/// </summary>
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("Cinemachine/Extensions/Lock Camera Y")]
public class LockCameraY : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    public float m_YPosition = 0f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = m_YPosition; // Corrected to lock Y position
            state.RawPosition = pos;
        }
    }
}