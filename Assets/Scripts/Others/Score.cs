using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Score : MonoBehaviour
{
    public int OGnumber = 0;
    //public Text scoreText; 
    //public int displayScore;
    public int OtherNum; 


    public void AddScore()
    {
        OtherNum = OGnumber + 1; 
        Debug.Log("Current Score : "+ OtherNum);
    }

    /*void Update()
    {
        displayScore = OtherNum;
        Debug.Log("Current Num is: " + displayScore);
        scoreText.text = displayScore.ToString();
    }*/

}

    


