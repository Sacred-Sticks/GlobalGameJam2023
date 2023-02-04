using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int health;

    public void ChangeHealth(int healthModification)
    {
        health += healthModification;
        if (health < 1) {
            Destroy(gameObject);
        }
    }
}
