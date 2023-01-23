using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
  public int FValue = 1;
  Animator an;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(FValue);
            // an.SetBool("Collect",true)
            Destroy(gameObject);
        }
    }

    // private void Update()
    // {
    //     // if (other.gameObject.CompareTag("Player"))
    //     // {
    //     //     an.SetBool("Collect", true);
    //     // }
    // }



}





