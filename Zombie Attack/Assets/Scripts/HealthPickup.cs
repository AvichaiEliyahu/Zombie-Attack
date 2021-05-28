using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.1f;
        
    float currenOffset;
    PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        currenOffset = 0;
    }

    private void Update()
    {
        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Pickup();
    }

    private void Pickup()
    {
        player.RestoreHealth();
        Destroy(gameObject);
    }
}
