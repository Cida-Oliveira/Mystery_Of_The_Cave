using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
   public void ShowGameOver()
   {
        gameOver.SetActive(true);
   }

   public void RestartGame(string name)
   {
        SceneManager.LoadScene(name);
   }
}
