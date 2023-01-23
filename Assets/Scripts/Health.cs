using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float startingHealth;
    [SerializeField] private float TrapDamage;
    [SerializeField] private AudioSource Hitsound;
    [SerializeField] private AudioSource Deathsound;
    public float currentHealth { get; private set; }
    private Animator an;
    public Image HPbar;
    
    
    private void Awake()
    {
        currentHealth = startingHealth;
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Trap"))
    //     {
    //         TakeDamage(1);
    //         an.SetTrigger("Hurt");
    //     }
    // }
    
    
    
    
    
    public void TakeDamage(float _damage)
    { 
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        Debug.Log(currentHealth);

        float Fill = currentHealth/startingHealth;

        HPbar.fillAmount = Fill;

        
        if (currentHealth > 0)
        {
            Hitsound.Play();
            an.SetTrigger("Hurt");
           
        }
        else if (currentHealth <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            if (rb.bodyType == RigidbodyType2D.Static)
            {
            Deathsound.Play();
            an.SetTrigger("Death");
            }
           
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
