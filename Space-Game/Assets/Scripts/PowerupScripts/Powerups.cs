using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{ 
    //Properties
    private int _Timer = 0;
    private double _Multiplier = 0;

    //Constructor
    public Powerups()
    {   SetTimer(_Timer);
        SetMultiplier(_Multiplier);
    }

    //Get & Set functions
    public void SetTimer(int Time)
    {   _Timer = Time;
    }

    public int GetTimer()
    {   return _Timer;
    }

    public void SetMultiplier(double Multiplier)
    {   _Multiplier = Multiplier;
    }

    public double GetMultiplier()
    {   return _Multiplier;
    }
}
