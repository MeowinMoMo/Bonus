using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallKill : MonoBehaviour
{
    public int Respawn;
    

    void RestartLevel(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
