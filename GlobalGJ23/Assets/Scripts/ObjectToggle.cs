using UnityEngine;

public class ObjectToggle : MonoBehaviour
{
    [SerializeField] private bool currentlyActive;
    [SerializeField] private GameObject target;

    private void Start() {
        target.SetActive(currentlyActive);
    }

    public void ToggleActive() {
        currentlyActive = !currentlyActive;
        target.SetActive(currentlyActive);
    }
}
