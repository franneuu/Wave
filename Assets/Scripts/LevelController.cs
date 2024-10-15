using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public HelicopterHealth helicopterHealth;
    public Timer temporizador;
    public int enemiesKilled;
    public int enemiesSpawned;
    public GameObject gameOverUI;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        CheckEnemies();
        if (temporizador.remaningTime <= 0)
        {
            LoseGame();
        }
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void CheckEnemies()
    {
        if (enemiesKilled == enemiesSpawned && helicopterHealth.chopperDead == true && temporizador.remaningTime > 0)
        {
            WinGame();
        }
    }
    public void LoseGame()
    {
        
        Debug.Log("¡Tiempo agotado! Has perdido.");
        gameOverUI.SetActive(true);
        //SceneManager.LoadScene(0);
        // Mostrar pantalla de derrota
    }
    void WinGame()
    {
        Debug.Log("¡Has impedido que los enemigos se escapen!");
        SceneManager.LoadScene(0);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
