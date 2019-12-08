using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerDebug : MonoBehaviour
{
   public Rigidbody2D p1;
   public Rigidbody2D p2;
    void Start()
    {
       
    }
    void Update()
    {
        p1.velocity = Vector2.up * Input.GetAxis("VerticalP1") * Time.deltaTime * 300;
        p2.velocity = Vector2.up * Input.GetAxis("VerticalP2") * Time.deltaTime * 800;
     
    }
}


