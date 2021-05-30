using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            Pickup();
    }

    private void Pickup()
    {
        FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
        source.Play();
        DestroyAfterSound();
    }

    private void DestroyAfterSound()
    {
        foreach (Transform child in gameObject.transform)
            child.gameObject.SetActive(false);
        Destroy(gameObject, source.clip.length);
    }
}
