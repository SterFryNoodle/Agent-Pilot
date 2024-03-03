using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;

    public void ScoreIncrease(int amountToIncrease) //Made public function so other classes can access
    {
        score += amountToIncrease;

        Debug.Log("Points: " + score);
    }
}
