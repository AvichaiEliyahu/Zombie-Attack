using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float timeToDisapear;

    // Start is called before the first frame update
    void Start()
    {
        impactCanvas.enabled = false;
    }

    // Update is called once per frame
    public void ShowDamageImpact()
    {
        StartCoroutine(DisplaySplatter());
    }

    IEnumerator DisplaySplatter()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(timeToDisapear);
        impactCanvas.enabled = false;
    }
}
