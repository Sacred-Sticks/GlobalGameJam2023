using UnityEngine;
using UnityEngine.Events;

public class StatusDetector : MonoBehaviour
{
    [SerializeField] private GameObject topCover;
    [SerializeField] private GameObject bottomCover;
    [SerializeField] private float bookOpenAngle;
    [SerializeField] private float bookCloseAngle;

    [SerializeField] private UnityEvent bookOpened;
    [SerializeField] private UnityEvent bookClosed;

    private bool bookOpen;

    private float top;
    private float bottom;

    private void Update() {
        top = topCover.transform.rotation.eulerAngles.z;
        if (top > 350)
            top -= 360;
        bottom = bottomCover.transform.rotation.eulerAngles.z;
        if (bottom > 350)
            bottom -= 360;
        if (!bookOpen && Mathf.Abs(top + bottom) > bookOpenAngle) {
            bookOpened.Invoke();
            bookOpen = true;
        }

        if (bookOpen && Mathf.Abs(top + bottom) < bookCloseAngle) {
            bookClosed.Invoke();
            bookOpen = false;
        }
    }

    public void open() {
        Debug.Log("Opened");
    }

    public void close() {
        Debug.Log("Closed");
    }
}
