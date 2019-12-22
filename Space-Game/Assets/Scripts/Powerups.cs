using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{ 
    //Properties
    private int _Timer = 1;
    
    //Get & Set functions
    public void SetTimer(int Timer)
    {   _Timer = Timer;
    }

    public int GetTimer()
    {   return _Timer;
    }
}
