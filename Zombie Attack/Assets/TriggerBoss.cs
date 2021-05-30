using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    [SerializeField] EnemyAI enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            enemy.OnDamageTaken();
    }
}
