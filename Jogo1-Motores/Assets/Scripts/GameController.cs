using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject vitoria;
    public static GameController instance;
    void Start()
    {
        instance = this;
        
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void ShowVitoria()
    {
        vitoria.SetActive(true);
    }

    public void RestartGame(string cena)
    {
        SceneManager.LoadScene(cena);
    }

   
   
}
