using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    [SerializeField] int triggerTextNum;
    StoryCanvas storyCanvas;
    

    void Start()
    {
        storyCanvas = FindObjectOfType<StoryCanvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            storyCanvas.SetTextFromArray(triggerTextNum);
            Destroy(gameObject);
        }
    }
}
