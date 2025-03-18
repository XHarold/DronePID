using UnityEngine;

public class getDrone : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // 暴露参数
    public float Speed => _rb.velocity.magnitude;  // 速度（米/秒）
    public float Height => transform.position.y;   // 高度（世界坐标Y轴）
    public Vector3 Direction => transform.forward; // 方向向量
    public float CompassAngle => transform.eulerAngles.y; // 指南针角度（0~360°）
}