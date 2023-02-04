using UnityEngine;
using TMPro;

public class KeypadButton : MonoBehaviour
{
    [SerializeField] private float pressDistance = 0.05f;
    private Vector3 unpressedPosition;
    private Vector3 pressedPosition;
    private char key = ' ';
    private Safe safe;
    
    void Start()
    {
        unpressedPosition = transform.position;
        pressedPosition = unpressedPosition + pressDistance * Vector3.back;
        safe = GetComponentInParent<Safe>();
        key = GetComponentInChildren<TextMeshPro>().text[0];
    }

    void OnMouseDown()
    {
        if (key == 'C')
            safe.ClearEntry();
        else
            safe.Press(key);

        transform.position = pressedPosition;
    }

    void OnMouseUp()
    {
        transform.position = unpressedPosition;
    }
}
