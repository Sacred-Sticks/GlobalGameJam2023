using System.Collections;
using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] private float restDegrees = 0;
    [SerializeField] private float turnedDegrees = -40;
    [SerializeField] private float transitionSeconds = 0.5f;
    private Safe safe;
    private Hinge hinge;

    void Start()
    {
        safe = GetComponentInParent<Safe>();
        hinge = GetComponentInParent<Hinge>();
    }

    public void OnMouseDown()
    {
        Turn();
    }

    public void Turn()
    {
        StopAllCoroutines();
        StartCoroutine(TurnRoutine());
    }

    IEnumerator TurnRoutine()
    {
        float startDegrees = transform.localRotation.eulerAngles.z;
        for (float t = 0; t < transitionSeconds; t += Time.deltaTime)
        {
            transform.localRotation = Quaternion.Euler(0, 0, Mathf.SmoothStep(startDegrees, turnedDegrees, t / transitionSeconds));
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0, 0, turnedDegrees);

        if (safe.CanOpen)
        {
            hinge.Open();
        }
        else
        {
            for (float t = 0; t < transitionSeconds; t += Time.deltaTime)
            {
                transform.localRotation = Quaternion.Euler(0, 0, Mathf.SmoothStep(turnedDegrees, startDegrees, t / transitionSeconds));
                yield return null;
            }

            transform.localRotation = Quaternion.Euler(0, restDegrees, 0);
        }
    }
}
