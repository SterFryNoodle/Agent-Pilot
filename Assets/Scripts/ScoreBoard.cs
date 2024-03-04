using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    TMP_Text scoreDisplay;

    void Start()
    {
        scoreDisplay = GetComponent<TMP_Text>();        
        scoreDisplay.text = "Points: "; //Initial text display at start
    }

    public void ScoreIncrease(int amountToIncrease) //Made public function so other classes can access
    {
        score += amountToIncrease;        
        scoreDisplay.text = "Points: " + score.ToString(); //Converts score value into string and updates
    }


}
