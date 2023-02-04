using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Indicates which scenarios are successfully completed
    public static bool tpSolved = false;
    public static bool survivalSolved = false;
    public static bool barSolved = false;
    // Is the whiteout still visible?
    public static bool overlayEnabled = false;
    // The whiteout overlay used for transitions

    // Start is called before the first frame update
    void Start()
    {
        overlayEnabled = false;
        // Get the whiteout overlay
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void CreateTransition(int newScene, bool useWhiteout)
    {
        if (useWhiteout)
        {
            // Fade in the whiteout over a second
            overlayEnabled = true;
        }
        SceneManager.LoadScene(newScene);
    }
}
