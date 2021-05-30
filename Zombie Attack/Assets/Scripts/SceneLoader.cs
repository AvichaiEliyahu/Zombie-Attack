using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Canvas startGameCanvas;
    [SerializeField] Canvas pauseGameCanvas;
    [SerializeField] Canvas controlsCanvas;

    private void Start()
    {
        startGameCanvas.enabled = true;
        pauseGameCanvas.enabled = false;
        controlsCanvas.enabled = false;
        FreezeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGameCanvas.enabled = true;
            FreezeGame();
        }
    }
    public void StartGame()
    {
        startGameCanvas.enabled = false;
        UnfreezeGame();
    }

    public void ResumeGame()
    {
        pauseGameCanvas.enabled = false;
        controlsCanvas.enabled = false;
        UnfreezeGame();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ShowControls()
    {
        pauseGameCanvas.enabled = false;
        controlsCanvas.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void FreezeGame()
    {
        FindObjectOfType<Weapon>().enabled = false;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MuteAllEnemies(true);
    }

    private void UnfreezeGame()
    {
        FindObjectOfType<WeaponSwitcher>().enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1;
        MuteAllEnemies(false);
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<Weapon>().enabled = true;
    }

    private void MuteAllEnemies(bool mute)
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth enemy in enemies)
        {
            enemy.GetComponent<AudioSource>().mute = mute;
        }
    }
}
