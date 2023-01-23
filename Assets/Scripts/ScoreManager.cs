using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text text;
    int score = 0;
    // int highscore = 0;



    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void ChangeScore(int FValue)
    {
        score += FValue;
        text.text = "X" + score.ToString();
    }
}