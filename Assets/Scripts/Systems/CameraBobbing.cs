using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBobbing : MonoBehaviour
{
    [Header("Transform references")]
    [SerializeField] private Transform headTransform;
    [SerializeField] private Transform cameraTransform;

    [Header("Head Bobbing")]
    [SerializeField] private float bobFrequency = 5f;
    [SerializeField] private float bobHorizontalAmplitude = 0.1f;
    [SerializeField] private float bobVerticalAmplitude = 0.1f;
    [Range (0,1)] [SerializeField] private float headBobSmoothing = 0.1f;

    public bool IsWalking { get; set; }
    private float walkingTime;
    private Vector3 targerCameraPosition;

    private void Update()
    {
        if (!IsWalking) walkingTime = 0;
        else walkingTime += Time.deltaTime;

        targerCameraPosition = headTransform.position + CalculateHeadBobOffset(walkingTime);

        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targerCameraPosition, headBobSmoothing);
        if ((cameraTransform.position - targerCameraPosition).magnitude <= 0.01) cameraTransform.position = targerCameraPosition;
    }

    private Vector3 CalculateHeadBobOffset(float t)
    {
        float horizontalOffset = 0;
        float verticalOffset = 0;
        Vector3 offset = Vector2.zero;

        if(t >0)
        {
            horizontalOffset = Mathf.Cos(t * bobFrequency) * bobHorizontalAmplitude;
            verticalOffset = Mathf.Sin(t * bobFrequency * 2) * bobVerticalAmplitude;

            offset = transform.right * horizontalOffset + headTransform.up * verticalOffset;
        }
        return offset;

    }

    public void ReduseBobbing(float reductionHeadBobbibgCoefficient)
    {
        bobFrequency = bobFrequency / reductionHeadBobbibgCoefficient;
        bobHorizontalAmplitude = bobHorizontalAmplitude / reductionHeadBobbibgCoefficient;
        bobVerticalAmplitude = bobVerticalAmplitude / reductionHeadBobbibgCoefficient;
    }

}
