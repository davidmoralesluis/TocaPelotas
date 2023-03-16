using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    public Camera camVerde;
    public Camera camRojo;
    public GameObject player;
    private bool cam2;


    // Start is called before the first frame update
    void Start()
    {
        camVerde.enabled = true;
        camRojo.enabled = false;
        cam2 = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerController1.cambioCamera==2)
        {
            camVerde.enabled = false;
            camRojo.enabled = true;
            cam2 = true;
        }
        
        transform.position = player.transform.position + new Vector3(0, 10, -15);
    }


}