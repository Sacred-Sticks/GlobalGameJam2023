using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Autohand;
using System.Linq;
using System.Collections;

public class ToiletPaperCounter : MonoBehaviour
{
    [SerializeField] private UnityEvent OnThrowingFinished;
    [SerializeField] private UnityEvent OnNextLevel;

    private int count;

    private void Awake() {
        List<Grabbable> rolls = GameObject.FindObjectsOfType<Grabbable>().ToList();
        count = rolls.Count;
    }

    public void LowerCount(Grabbable grabbable) {
        count--;
        Destroy(grabbable);
        Debug.Log($"Count at {count}");
        if (count == 0) {
            StartCoroutine(NextLevel(5));
        }
    }

    private IEnumerator NextLevel(int timeDelay) {
        OnThrowingFinished.Invoke();
        yield return new WaitForSeconds(timeDelay);
        OnNextLevel.Invoke();
    }

}
