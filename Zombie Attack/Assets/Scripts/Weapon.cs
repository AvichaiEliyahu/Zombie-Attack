using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoAmountText;

    bool canShoot = true;
    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        ProcessShoot();
        DisplayAmmo();
    }

    private void DisplayAmmo()
    {
        ammoAmountText.SetText("Ammo: "+ammoSlot.GetCurrentAmmo(ammoType).ToString());
    }

    private void ProcessShoot()
    {
        if (Input.GetMouseButtonDown(0))
            if (ammoSlot.GetCurrentAmmo(ammoType) > 0 && canShoot)
                StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo(ammoType);

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
                return;
            target.TakeDamage(damage);
        }
        else return;
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
