using UnityEngine;
using Fungus;

public class Ring : MonoBehaviour
{
    [Header("材质设置")]
    [SerializeField] private Material normalMaterial;    // 默认材质
    [SerializeField] private Material triggeredMaterial; // 触发后材质
    [SerializeField] private float switchDuration = 1f;  // 材质切换持续时间

    [Header("Fungus 配置")]
    [SerializeField] private Flowchart flowchart; // 拖拽 Flowchart 对象到 Inspector
    [SerializeField] private string targetBlockName; // 每个圆环可以设置不同的 Block 名称

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
        // 切换材质
        _meshRenderer.material = triggeredMaterial;
        _isTriggered = true;

        // 触发 Fungus 对话
        if (flowchart != null)
        {
            flowchart.ExecuteBlock(targetBlockName);
        }
    }


}