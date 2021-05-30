using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePlatform : MonoBehaviour
{
    [SerializeField] Canvas endGameCanvas;

    void Start()
    {
        endGameCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            endGameCanvas.enabled = true;
            FreezeGame();
        }
    }

    private void FreezeGame()
    {
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
