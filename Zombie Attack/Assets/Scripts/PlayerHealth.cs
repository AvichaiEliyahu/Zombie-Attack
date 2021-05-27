using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    DeathHandler deathHandler;

    private void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    private void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        healthText.SetText("Health: "+hitPoints);
    }

    public void TakeDamage(float damage)
    {
        DecreaseHealth(damage);
        ProcessDeath();
    }

    private void DecreaseHealth(float damage)
    {
        hitPoints -= damage;
    }

    private void ProcessDeath()
    {
        if (hitPoints <= 0)
            deathHandler.HandleDeath();
    }
}
