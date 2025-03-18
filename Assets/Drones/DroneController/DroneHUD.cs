using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DroneHUD : MonoBehaviour
{
    [Header("���˻�����")]
    [SerializeField] private getDrone drone;

    [Header("UI ���")]
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text heightText;
    [SerializeField] private TMP_Text directionText;
    [SerializeField] private Image compassNeedle;

    void Update()
    {
        UpdateSpeed();
        UpdateHeight();
        UpdateDirection();
        UpdateCompass();
    }

    private void UpdateSpeed()
    {
        speedText.text = $"Speed: {drone.Speed:F2} m/s";
    }

    private void UpdateHeight()
    {
        heightText.text = $"Height: {drone.Height:F1} m";
    }

    private void UpdateDirection()
    {
        directionText.text = $"Direction: {drone.CompassAngle:F0}��";
    }

    private void UpdateCompass()
    {
        float targetAngle = -drone.CompassAngle;
        float smoothAngle = Mathf.LerpAngle(compassNeedle.rectTransform.eulerAngles.z, targetAngle, 0.1f);
        compassNeedle.rectTransform.rotation = Quaternion.Euler(0, 0, smoothAngle);
    }
}