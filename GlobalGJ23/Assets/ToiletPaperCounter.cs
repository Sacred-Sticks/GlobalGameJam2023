using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Autohand;
using System.Linq;

public class ToiletPaperCounter : MonoBehaviour
{
    [SerializeField] private UnityEvent OnThrowingFinished;

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
            OnThrowingFinished.Invoke();
        }
    }

}
