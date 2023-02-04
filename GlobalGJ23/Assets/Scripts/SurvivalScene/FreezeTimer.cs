using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTimer : MonoBehaviour
{
    // Time to freeze in seconds
    [SerializeField] public float maxTime = 180.0f;
    public float freezeTime;
    // Whether to update the timer and perform its actions
    public bool timerActive = true;
    public bool timeFinished = false;
    // The maximum opacity of the frost overlay
    private float maxOpacity = 0.5f;
    //private image overlay = gameObject.GetComponent(typeof(image));
    [SerializeField] private Color color;
    private Image image;

    void Start()
    {
        freezeTime = maxTime;
        image = GetComponent<Image>();
        color = image.color;
    }

    void Update()
    {
        if (timerActive)
        {
            freezeTime -= Time.deltaTime;
            color.a = (1 - (freezeTime/maxTime)) * maxOpacity;
            image.color = color;
            if (freezeTime <= 0.0f)
            {
                TimeEnded();
            }
        }
        else if (timeFinished)
        {
            if (image.color.a < 1)
            {
                float timeOverlap = Time.deltaTime;
                color.a += timeOverlap;
                image.color = color;
                timeOverlap = 0.0f;
            }
        }
    }

    void TimeEnded()
    {
        timeFinished = true;
        timerActive = false;
        color.a = maxOpacity;
        image.color = color;
        StartCoroutine(WaitThenTransition());
    }
    IEnumerator WaitThenTransition()
    {
        yield return new WaitForSeconds(5);
        // Do a transition
    }
}
