using System.Collections;
using UnityEngine;

public class Hinge : MonoBehaviour
{
    [SerializeField] private float closedDegrees = 0;
    [SerializeField] private float openDegrees = -120;
    [SerializeField] private float transitionSeconds = 2;

    public void Open()
    {
        StopAllCoroutines();
        StartCoroutine(SmoothStepTo(openDegrees));
    }

    public void Close()
    {
        StopAllCoroutines();
        StartCoroutine(SmoothStepTo(closedDegrees));
    }

    IEnumerator SmoothStepTo(float targetDegrees)
    {
        float startDegrees = transform.localRotation.eulerAngles.y;
        for (float t = 0; t < transitionSeconds; t += Time.deltaTime)
        {
            transform.localRotation = Quaternion.Euler(0, Mathf.SmoothStep(startDegrees, targetDegrees, t / transitionSeconds), 0);
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0, targetDegrees, 0);
    }
}
