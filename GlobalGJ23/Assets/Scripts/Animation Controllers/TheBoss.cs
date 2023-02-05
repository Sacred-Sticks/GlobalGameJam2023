using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TheBoss : MonoBehaviour {
    [SerializeField] private float idleDistance;
    [SerializeField] private float attackTimeDuration;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Animator bossAnimator;

    private const int IDLE = 0;
    private const int WALKING = 1;
    private const int ATTACKING = 2;

    private NavMeshAgent agent;
    private bool isAttacking;
    private bool walking = false;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (agent.remainingDistance >= idleDistance) {
            bossAnimator.SetInteger("Animation State", WALKING);
            return;
        }
        if (!isAttacking) {
            StartCoroutine(AttackDelay());
        }
    }

    private IEnumerator AttackDelay() {
        isAttacking = true;
        bossAnimator.SetInteger("Animation State", ATTACKING);
        yield return new WaitForSeconds(attackTimeDuration);
        bossAnimator.SetInteger("Animation State", IDLE); 
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
