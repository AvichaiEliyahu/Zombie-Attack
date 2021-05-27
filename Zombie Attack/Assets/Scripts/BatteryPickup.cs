using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<Flashlight>().RestoreFlashlightCondition();
            Destroy(gameObject);
        }
    }
}
