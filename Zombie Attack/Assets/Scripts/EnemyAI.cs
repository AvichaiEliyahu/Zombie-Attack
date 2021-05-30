using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float ChaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] AudioClip[] zombieSounds;

    AudioSource source;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        source = GetComponent<AudioSource>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position,target.position);
        if (isProvoked)
        {
            EngageTarget();
            if(!source.isPlaying)
                PlayRandomSound();
        }
        else if (distanceToTarget <= ChaseRange)
            isProvoked = true;
        if (health.IsDead())
        {
            navMeshAgent.enabled = false;
            enabled = false;
        }
    }

    private void PlayRandomSound()
    {
        int chanceToPlay = UnityEngine.Random.Range(0, 200);
        if (chanceToPlay == 1)
        {
            int randomSound = UnityEngine.Random.Range(0, zombieSounds.Length);
            source.clip = zombieSounds[randomSound];
            source.Play();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
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
