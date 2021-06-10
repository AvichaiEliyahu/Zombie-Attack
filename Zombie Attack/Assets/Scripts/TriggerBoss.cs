using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    [SerializeField] EnemyAI[] enemies;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            foreach(EnemyAI enemy in enemies)
                enemy.OnDamageTaken();
    }
}
