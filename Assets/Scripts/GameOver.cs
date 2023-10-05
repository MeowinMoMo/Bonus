using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointText;
    public Text fruittext;

    public Text Timer;
    public Text TimerFin;
    public void Update()
    {
        pointText.text = "Fruits gathered : " + fruittext.text;
        Timer.text = "Time took : " + TimerFin.text;

    }
     public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     public void QuitGame ()
    {
      Debug.Log("Quit Bye Bye");
      Application.Quit();
    }

    public void Back ()
    {
        SceneManager.LoadScene("Menuni");
    }
}
