using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private const string PREFIX = "Score: ";
    private static int _scoreValue;
    private Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {   _scoreValue = 0;                                 //Default value should start at 0.        
        _scoreText = GetComponent<Text>();               //Grab text component for the UI.
    }

    // Update is called once per frame
    void Update()
    {   _scoreText.text = PREFIX + _scoreValue;
    }

    //Getter/Setter
    public static int GetScoreValue()
    {   return _scoreValue;
    }

    //Methods
    public static void ModifyScore(int value)
    {   if (_scoreValue + value > 0)                     //Do not allow negative score.
            _scoreValue += value;
        else
            _scoreValue = 0;
    }
}
