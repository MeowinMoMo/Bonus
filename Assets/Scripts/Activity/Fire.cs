using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // [SerializeField] private Transform barrel;
    // [SerializeField] private GameObject Rock;
    // [SerializeField] private GameObject[] ammo;
    // Animator ani;
    // private int ammoAmount;
    
    // Start is called before the first frame update
    // void Start()
    // {
    //     for (int i = 0; i <= 3; i++)
    //     {
    //         ammo[i].gameObject.SetActive(false);
    //     }

    //     ammoAmount = 0;
        
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetButtonDown("Fire1") && ammoAmount > 0)
    //     {
    //         var spawnedBullet = Instantiate(Rock, barrel.position, barrel.rotation);
    //         spawnedBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500f);
    //         ammoAmount -= 1;
    //         ani.SetTrigger("Shoot");
    //         ammo[ammoAmount].gameObject.SetActive(false);
    //     }
    //     if (Input.GetKey(KeyCode.R))
    //     {
    //         ammoAmount = 4;
    //         for (int i = 0; i <= 3; i++)
    //         {
    //             ammo[i].gameObject.SetActive(true);
    //         }
    //     }
    // }
}
