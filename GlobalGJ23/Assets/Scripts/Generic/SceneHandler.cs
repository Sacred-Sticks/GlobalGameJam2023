using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    // The whiteout overlay used for transitions
    [SerializeField] public Image transitionOverlay;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        if (transitionOverlay != null)
        {
            color = transitionOverlay.color;
            color.a = 1f;
            transitionOverlay.color = color;
            while (transitionOverlay.color.a > 0f)
            {
                float timePassed = Time.deltaTime;
                color.a -= timePassed;
                transitionOverlay.color = color;
                timePassed = 0f;
                //Debug.Log(transitionOverlay.color.a);
            }
        }
        else Debug.LogWarning("Transition overlay not specified. No visuals will be used for scene transitions.");
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void CreateTransition(int newScene)
    {
        if (transitionOverlay != null)
        {
            // Fade in the whiteout over a second
            while (transitionOverlay.color.a < 1f)
            {
                float timePassed = Time.deltaTime;
                color.a += timePassed;
                transitionOverlay.color = color;
                timePassed = 0f;
            }
        }
        SceneManager.LoadScene(newScene);
    }
}
