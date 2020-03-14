using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetexplode : MonoBehaviour
{
    public int planetHealth = 35;

    // Start is called before the first frame update
    void Start()
    {
        planetHealth = 35;
        

    }

    private void OnTriggerStay(Collider bullet)
    {
        if (planetHealth<0)
        {
            BlowUp();
        }
    }


    void BlowUp ()
    {
        Object.Destroy(gameObject);
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
