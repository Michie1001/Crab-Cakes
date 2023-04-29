using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float detectionRange = 10f;
    public float chaseSpeed = 5f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackCooldown = 2f;

    private int currentPatrolPoint = 0;
    private Transform player;
    private Animator animator;
    private float lastAttackTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if player is within detection range
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            // Player detected, start chasing
            animator.SetBool("IsPatrolling", false);
            animator.SetBool("IsChasing", true);
            transform.LookAt(player);
            transform.position += transform.forward * chaseSpeed * Time.deltaTime;

            // Check if player is within attack range
            if (Vector3.Distance(transform.position, player.position) < attackRange)
            {
                // Player in attack range, attempt attack
                if (Time.time - lastAttackTime > attackCooldown)
                {
                    lastAttackTime = Time.time;
                    player.SendMessage("TakeDamage", attackDamage);
                    animator.SetTrigger("Attack");
                }
            }
        }
        else
        {
            // Player not detected, patrol between waypoints
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsPatrolling", true);
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, chaseSpeed * Time.deltaTime);
            transform.LookAt(patrolPoints[currentPatrolPoint].position);

            // Check if enemy has reached patrol point
            if (Vector3.Distance(transform.position, patrolPoints[currentPatrolPoint].position) < 0.1f)
            {
                // Move to next patrol point
                currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
            }
        }
    }
}
