using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.1f;

    AudioSource source;
    float currenOffset;
    PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !player.isHealthFull())
            Pickup();
    }

    private void Pickup()
    {
        source.Play();
        player.RestoreHealth();
        //Destroy(gameObject, source.clip.length/4);
        DestroyAfterSound();
    }

    private void DestroyAfterSound()
    {
        foreach (Transform child in gameObject.transform)
            child.gameObject.SetActive(false);
        Destroy(gameObject, source.clip.length);
    }
}
