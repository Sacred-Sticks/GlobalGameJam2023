using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    // Indicates which scenarios are successfully completed
    public static bool tpSolved = false;
    public static bool survivalSolved = false;
    public static bool barSolved = false;
    // Is the whiteout still visible?
    public static bool overlayEnabled = false;
    // The whiteout overlay used for transitions
    [SerializeField] public Image transitionOverlay;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        if (transitionOverlay != null)
        {
            color = transitionOverlay.color;
            if (overlayEnabled)
            {
                while (transitionOverlay.color.a > 0f)
                {
                    float timePassed = Time.deltaTime;
                    color.a -= timePassed;
                    transitionOverlay.color = color;
                    timePassed = 0f;
                }
            }
        }
        else Debug.LogWarning("Transition overlay not specified. No visuals will be used for scene transitions.");
        overlayEnabled = false;
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void CreateTransition(int newScene, bool useWhiteout)
    {
        if (useWhiteout && transitionOverlay != null)
        {
            // Fade in the whiteout over a second
            overlayEnabled = true;
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
