using UnityEngine;
using Fungus;

public class Ring : MonoBehaviour
{
    [Header("��������")]
    [SerializeField] private Material normalMaterial;    // Ĭ�ϲ���
    [SerializeField] private Material triggeredMaterial; // ���������
    [SerializeField] private float switchDuration = 1f;  // �����л�����ʱ��

    [Header("Fungus ����")]
    [SerializeField] private Flowchart flowchart; // ��ק Flowchart ���� Inspector
    [SerializeField] private string targetBlockName; // ÿ��Բ���������ò�ͬ�� Block ����

    private MeshRenderer _meshRenderer;
    private bool _isTriggered;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = normalMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isTriggered)
        {
            HandleMaterialSwitch();
        }
    }

    private void HandleMaterialSwitch()
    {
        // �л�����
        _meshRenderer.material = triggeredMaterial;
        _isTriggered = true;

        // ���� Fungus �Ի�
        if (flowchart != null)
        {
            flowchart.ExecuteBlock(targetBlockName);
        }
    }


}