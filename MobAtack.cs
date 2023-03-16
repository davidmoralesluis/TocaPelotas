using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAtack : MonoBehaviour
{
    public int speed= 200;

    public Vector3 spawnMob1;
    public Vector3 spawnMob2;
    public bool spwan;
    
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        spwan = false;
        spawnMob1 = new Vector3(0, 1, 30);
        spawnMob2 = new Vector3(6, 1, 55);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player);
        this.transform.Translate(Vector3.forward*speed*Time.deltaTime);
        
        if (transform.position.y<-5)
        {
            if (spwan)
            {
                transform.position = spawnMob1;
                spwan = false;
            }
            else
            {
                transform.position = spawnMob2;
                spwan = true;
            }
            
        }

        if (PlayerController1.fin==true)
        {
            Destroy(gameObject);
        }
    }
}
