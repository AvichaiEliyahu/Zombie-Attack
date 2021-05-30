using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{

    float currentHitPoints;
    [SerializeField] float maxHitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    DeathHandler deathHandler;

    private void Start()
    {
        RestoreHealth();
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    private void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        healthText.SetText("Health: "+currentHitPoints);
    }

    public void TakeDamage(float damage)
    {
        DecreaseHealth(damage);
        ProcessDeath();
    }

    public bool isHealthFull()
    {
        return maxHitPoints == currentHitPoints;
    }

    public void RestoreHealth()
    {
        currentHitPoints = maxHitPoints;
    }

    private void DecreaseHealth(float damage)
    {
        currentHitPoints -= damage;
    }

    private void ProcessDeath()
    {
        if (currentHitPoints <= 0)
            deathHandler.HandleDeath();
    }
}
