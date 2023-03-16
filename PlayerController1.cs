using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController1 : MonoBehaviour
{
    public float speed = 500;

    private Rigidbody rb;
    public Vector3 posicionInical;

    public static float contadorAmarillo;
    public static float cambioCamera;
    public static bool fin;
    

    public float movementX;
    public float movementY;

    // Start is called before the first frame update
    void Start()
    {
        // instanciando el objeto que contiene este script
        // la bola
        rb = GetComponent<Rigidbody>();
        // mensaje para la consola del Unity
        Debug.Log("Estoy en Start ");
        posicionInical = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cambioCamera = 1;
        fin = false;
    }

    /**
     *  Evento Input System
     **/
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        // mensaje para la consola del Unity
        Debug.Log("Estoy en OnMove1 ,Y -> "+movementY+" ,x -> "+movementX);
    }

    private void FixedUpdate()
    {
        // para el teclado
        Vector3 movement = new Vector3( movementX, 0.0f, movementY);
        rb.AddForce(movement * speed *(Time.deltaTime));
        
        
        //Debug.Log("Deltatime -> "+Time.deltaTime);
        if (transform.position.y<-5)
        {
            transform.position = posicionInical;
            rb.AddForce(new Vector3( 0, 0.0f, 0)*0);
        }
        

        // recogemos los datos del acelerometro
        // Vector3 dir = Vector3.zero;
        // dir.x = -Input.acceleration.y;
        // dir.z = Input.acceleration.x;
        // if (dir.sqrMagnitude > 1)
        //     dir.Normalize();
        //
        // dir *= Time.deltaTime;
        // transform.Translate(dir * speed);
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse");
        // transform.Rotate(new Vector3(0,1,0),180);
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            contadorAmarillo++;
            Debug.Log("Has destruido "+contadorAmarillo+" cubos");
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.CompareTag("cambioCam"))
        {
            cambioCamera++;
            other.gameObject.SetActive(false);
            
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            fin = true;
        }
    }
}

