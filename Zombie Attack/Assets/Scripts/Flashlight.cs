using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float maxIntensity = 2f;
    [SerializeField] float maxAngle = 70f;


    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreFlashlightCondition()
    {
        RestoreLightAngle();
        RestoreLightIntensity();
    }

    void RestoreLightIntensity()
    {
        flashlight.intensity = maxIntensity;
    }

    void RestoreLightAngle()
    {
        flashlight.spotAngle = maxAngle;
    }

    void DecreaseLightIntensity()
    {
        flashlight.intensity -= lightDecay * Time.deltaTime;
    }
    void DecreaseLightAngle()
    {
        if(flashlight.spotAngle>minimumAngle)
            flashlight.spotAngle -= angleDecay * Time.deltaTime;
    }
}
