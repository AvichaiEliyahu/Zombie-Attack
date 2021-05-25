using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] float throwForce = 15.0f;
    [SerializeField] float blastRadius = 5.0f;
    [SerializeField] float damage = 80.0f;
    [SerializeField] float explosionDelay = 3.0f;
    [SerializeField] Camera FPCamera;
    [SerializeField] GameObject granadePrefab;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] Ammo ammoSlot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            if(ammoSlot.GetCurrentAmmo(AmmoType.Granades) > 0)
                ProccesGranade();
        
    }

    void ProccesGranade()
    {
        Debug.Log("pressed g");
        StartCoroutine( ThrowGranade());
        
    }

    IEnumerator ThrowGranade()
    {
        GameObject granade = Instantiate(granadePrefab, FPCamera.transform.position, FPCamera.transform.rotation) as GameObject;
        granade.GetComponent<Rigidbody>().AddForce(FPCamera.transform.forward * throwForce, ForceMode.Impulse);
        granade.GetComponent<Rigidbody>().useGravity = true;
        ammoSlot.ReduceCurrentAmmo(AmmoType.Granades);
        yield return new WaitForSeconds(explosionDelay);
        Explode(granade.transform);
        Destroy(granade);
    }

    void Explode(Transform granadeTransform)
    {
        PlayExplosionEffect(granadeTransform);
        Collider[] enemiesHitByGranade = Physics.OverlapSphere(granadeTransform.position, blastRadius);
        for (int i = 0; i < enemiesHitByGranade.Length; i++)
        {
            EnemyHealth enemy = enemiesHitByGranade[i].gameObject.GetComponent<EnemyHealth>();
            if (enemy)
            {
                float damageTaken = (1-(Vector3.Distance(granadeTransform.position, enemy.transform.position)
                    / blastRadius))*damage;
                Debug.Log("enemy at distance: " + Vector3.Distance(granadeTransform.position, enemy.transform.position) + "has taken: "+damageTaken +" damage");
                enemy.TakeDamage(damageTaken);
            }
        }
    }

    void PlayExplosionEffect(Transform explosiontransform)
    {
        GameObject explosion = Instantiate(explosionEffect, explosiontransform.position, Quaternion.identity);
        Destroy(explosion, 2);
    }
}
