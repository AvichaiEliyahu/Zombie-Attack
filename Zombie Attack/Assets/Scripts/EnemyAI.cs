using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float ChaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
   
    EnemySounds soundsPlayer;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        soundsPlayer = GetComponent<EnemySounds>();
    }

    void Update()
    {
        distanceToTarget = CalcDistance();
        if (isProvoked)
            EngageSequence();
        else if (distanceToTarget <= ChaseRange)
            isProvoked = true;

        if (health.IsDead())
            DeathSequence();
    }

    public float CalcDistance()
    {
        return Vector3.Distance(transform.position, target.position);
    }

    private void DeathSequence()
    {
        navMeshAgent.enabled = false;
        enabled = false;
        soundsPlayer.PlaySounds(SOUND_TYPE.DEATH);
    }

    private void EngageSequence()
    {
        EngageTarget();
        soundsPlayer.PlaySounds(SOUND_TYPE.ENGAGE);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
        soundsPlayer.PlaySounds(SOUND_TYPE.HIT);
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance)
            ChaseTarget();
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
            AttackTarget();
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        soundsPlayer.PlaySounds(SOUND_TYPE.ATTACK);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }
}
