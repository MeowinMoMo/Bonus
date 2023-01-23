using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    private int fruits = 0;
    [SerializeField] private Text Score;
    [SerializeField] private AudioSource Collectsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fruits"))
        {
            Animator an = collision.gameObject.GetComponent<Animator>();
            Collectsound.Play();
            an.SetBool("Collect",true);
            Destroy(collision.gameObject, 0.75f);
            fruits++;
            Score.text = "x" + fruits;
        }    
    }


}
