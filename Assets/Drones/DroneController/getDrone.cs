using UnityEngine;

public class getDrone : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // ��¶����
    public float Speed => _rb.velocity.magnitude;  // �ٶȣ���/�룩
    public float Height => transform.position.y;   // �߶ȣ���������Y�ᣩ
    public Vector3 Direction => transform.forward; // ��������
    public float CompassAngle => transform.eulerAngles.y; // ָ����Ƕȣ�0~360�㣩
}