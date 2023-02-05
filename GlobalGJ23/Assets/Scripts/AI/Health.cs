using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private UnityEvent onDeath;

    public void ChangeHealth(int healthModification)
    {
        health += healthModification;
        if (health < 1) {
            onDeath.Invoke();
        }
    }
}
