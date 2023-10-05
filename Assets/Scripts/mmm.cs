using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmm : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    GameObject.Find("Player").SendMessage("Finnish");
  }
}
