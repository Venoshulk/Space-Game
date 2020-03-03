using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{ 
    //Properties
    private int _Timer = 0;
    private double _Multiplier = 0;
    private int _ThisScoreValue = 0;

    //Get & Set functions
    public void SetTimer(int Time)
    {   _Timer = Time;
    }

    public int GetTimer()
    {   return _Timer;
    }

    public void SetMultiplier(double Multiplier)
    {   if(Multiplier != 0)
            _Multiplier = Multiplier;
    }

    public double GetMultiplier()
    {   return _Multiplier;
    }

    public void SetThisScoreValue(int value = 0)
    {   if(value > 0)
            _ThisScoreValue = value;
    }

    public int GetThisScoreValue()
    {   return _ThisScoreValue;
    }

    //Methods
    public void AddThisScore() 
    {   PlayerScore.ModifyScore(_ThisScoreValue);
    }
}
