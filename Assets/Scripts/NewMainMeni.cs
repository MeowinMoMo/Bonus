using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMainMeni : MonoBehaviour
{
    public void Start ()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void Exit ()
   {
      Debug.Log("Quit Bye Bye");
      Application.Quit();
   }
}
