using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Health : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private StatusObject status;
    [SerializeField] private int damagePerHit;
    [SerializeField] private float attackDelay;

    private bool canAttack = true;

    [SerializeField] private LayerMask attackableLayers;

    private void OnTriggerEnter(Collider collision) {
        if (attackableLayers == (attackableLayers | (1 << collision.gameObject.layer))) {
            if (!canAttack) {
                return;
            }
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack() {
        ChangeHealth(-damagePerHit);
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    public void ChangeHealth(int healthModification)
    {
        health += healthModification;
        if (health < 1) {
            onDeath.Invoke();
        }
    }
}
