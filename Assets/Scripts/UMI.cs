using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMI : MonoBehaviour
{
    bool isLookingRight;
   
    Rigidbody2D rb;
    SpriteRenderer sr;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isLookingRight = !isLookingRight;

            if (isLookingRight)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    } 

   

}
