using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTimer : MonoBehaviour
{
    [SerializeField] public float maxTime = 180.0f;
    [SerializeField] private SceneHandler sceneHandler;
    [SerializeField] public Image freezeVisual;
    [SerializeField] public Transform breathSource;
    public float freezeTime;
    public bool timerActive = true;
    public bool timeFinished = false;
    private float maxOpacity = 0.5f;
    private Color color;
    //private Image image;

    void Start()
    {
        if (sceneHandler == null)
        {
            Debug.LogWarning("Scene handler not defined. Transitions will not be performed.");
        }
        if (breathSource == null)
        {
            Debug.LogWarning("Breath source not defined. Cold breath will not display.");
        }
        if (freezeVisual == null)
        {
            Debug.LogWarning("Frost overlay not defined. Overlay function will be unused.");
        }
        else color = freezeVisual.color;
        freezeTime = maxTime;
    }

    void Update()
    {
        if (timerActive)
        {
            freezeTime -= Time.deltaTime;
            if (freezeVisual != null)
            {
                color.a = (1 - (freezeTime / maxTime)) * maxOpacity;
                freezeVisual.color = color;
            }
            if (freezeTime <= 0.0f)
            {
                TimeEnded();
            }
        }
        else if (timeFinished)
        {
            if (freezeVisual != null && freezeVisual.color.a < 1f)
            {
                float timePassed = Time.deltaTime;
                color.a += timePassed;
                freezeVisual.color = color;
                timePassed = 0.0f;
            }
        }
        else if (!timerActive && freezeVisual != null)
        {
            color.a = 0.0f;
            freezeVisual.color = color;
        }
    }

    void TimeEnded()
    {
        timeFinished = true;
        timerActive = false;
        color.a = maxOpacity;
        freezeVisual.color = color;
        sceneHandler.overlayOn = true;
        StartCoroutine(WaitThenTransition());
    }

    IEnumerator WaitThenTransition()
    {
        yield return new WaitForSeconds(3);
        sceneHandler.CreateTransition(0, false);
    }
}
