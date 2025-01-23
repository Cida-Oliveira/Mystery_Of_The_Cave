using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public static GameController instance1;

    public GameObject gameOver;

    public GameObject vitoria;

    public GameObject restart;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        instance1 = this;
    }

    // Update is called once per frame
   public void ShowGameOver()
   {
    //ativa algo na unitys
        gameOver.SetActive(true);
   }

   public void ShowVitoria()
   {
       vitoria.SetActive(true);
   }

   public void ShowRestartGame(string lvlNmae)
   {
      SceneManager.LoadScene(lvlNmae);
      restart.SetActive(true);

   }
}
