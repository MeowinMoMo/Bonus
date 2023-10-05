using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public Text timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    private bool Finnished = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Finnished)
            return;
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0.00");
    }

    public void Finnish()
    {
        Finnished = true;
        timerText.color = Color.yellow;
    }
}
