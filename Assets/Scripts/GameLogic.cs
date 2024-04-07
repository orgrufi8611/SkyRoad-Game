using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
