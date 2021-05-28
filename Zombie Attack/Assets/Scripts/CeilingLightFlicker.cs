using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingLightFlicker : MonoBehaviour
{
    Light ceilingLight;
    float onTime;
    [SerializeField] float randomMinTime;
    [SerializeField] float randomMaxTime;
    

    private void Start()
    {
        ceilingLight = GetComponentInChildren<Light>();
        StartCoroutine(Flicker());
    }

    private void Update()
    {
        
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            onTime = Random.Range(randomMinTime, randomMaxTime);
            yield return new WaitForSeconds(onTime);
            ceilingLight.enabled = !ceilingLight.enabled;
        }
       
        
    }
}
