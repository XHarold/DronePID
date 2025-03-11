using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform drone; // 无人机物体

    void LateUpdate()
    {
        if (drone == null) return;

        // 计算目标方向，但保持Y轴不变
        Vector3 targetPosition = drone.position;
        targetPosition.y = transform.position.y; // 保持摄像机高度不变

        // 让摄像机朝向无人机（只旋转水平角度）
        transform.LookAt(targetPosition);
    }
}
