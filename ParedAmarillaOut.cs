using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class ParedAmarillaOut : MonoBehaviour
{
    public float count = 0;
    private PlayerController1 test1;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        count = PlayerController1.contadorAmarillo;
        
        if (count>=8)
        {
            Destroy(gameObject);
        }
    }

    
}
