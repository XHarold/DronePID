using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform drone; // ���˻�����

    void LateUpdate()
    {
        if (drone == null) return;

        // ����Ŀ�귽�򣬵�����Y�᲻��
        Vector3 targetPosition = drone.position;
        targetPosition.y = transform.position.y; // ����������߶Ȳ���

        // ��������������˻���ֻ��תˮƽ�Ƕȣ�
        transform.LookAt(targetPosition);
    }
}
