using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private StatusObject status;

    public void ChangeHealth(int healthModification)
    {
        health += healthModification;
        if (health < 1) {
            onDeath.Invoke();
        }
    }

    public void playerDeath() {
        status.level = StatusObject.Level.AdultYears;
    }

    public void enemyDeath() {
        status.level = StatusObject.Level.Menu2;
    }
}
