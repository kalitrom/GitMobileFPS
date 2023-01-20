using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    [SerializeField] private int scaleTime;
    [SerializeField] private int reductionSize;
    [SerializeField] private int reductionSpeed;
    [SerializeField] private int reductionHeadBobbibgCoefficient;

    private PlayerMovementMobile playerMovementMobile;
    private CameraBobbing cameraBobbing;
    private Transform playerTransform;

    private void Start()
    {
        playerMovementMobile = FindObjectOfType<PlayerMovementMobile>();
        cameraBobbing = FindObjectOfType<CameraBobbing>();
        playerTransform = playerMovementMobile.gameObject.transform;
    }

    public void ReducePlayerSize()
    {
        StartCoroutine(_ReducePlayerSize(scaleTime));
        playerMovementMobile.ReduseCameraAndMovespeed(reductionSpeed);
        cameraBobbing.ReduseBobbing(reductionHeadBobbibgCoefficient);
    }

    IEnumerator _ReducePlayerSize(float time)
    {
        float i = 0;
        float rate = 1 / time;

        Vector3 fromScale = playerTransform.localScale;
        Vector3 toScale = new Vector3(fromScale.x / reductionSize, fromScale.y / reductionSize, fromScale.z / reductionSize);
        while (i < 1)
        {
            i += Time.deltaTime * rate;
            playerTransform.localScale = Vector3.Lerp(fromScale, toScale, i);
            yield return 0;
        }
    }
}
