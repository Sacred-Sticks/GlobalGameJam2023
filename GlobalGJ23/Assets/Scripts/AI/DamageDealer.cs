using System.Collections;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private LayerMask attackableLayers;
    [SerializeField] private int damagePerHit;
    [SerializeField] private float attackDelay;

    private bool canAttack = true;

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.TryGetComponent<Health>(out var target))
            return;
        if (attackableLayers == (attackableLayers | (1 << collision.gameObject.layer))) {
            if (!canAttack) {
                return;
            }
            StartCoroutine(Attack(target));
        }
    }

    private IEnumerator Attack(Health target) {
        target.ChangeHealth(-damagePerHit);
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
