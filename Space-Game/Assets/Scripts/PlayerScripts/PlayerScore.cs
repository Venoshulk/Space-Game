using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private static int scoreValue;
    private const string PREFIX = "Score: ";
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {   scoreValue = 0;                                 //Default value should start at 0.        
        scoreText = GetComponent<Text>();               //Grab text component for the UI.
    }

    // Update is called once per frame
    void Update()
    {   scoreText.text = PREFIX + scoreValue;
    }

    //Getter/Setter
    public int GetScoreValue()
    {   return scoreValue;
    }

    //Methods
    public static void ModifyScore(int value)
    {   if (scoreValue + value > 0)                     //Do not allow negative score.
            scoreValue += value;
        else 
            scoreValue = 0;
    }
}
