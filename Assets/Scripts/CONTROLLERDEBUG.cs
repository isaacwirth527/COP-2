using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CONTROLLERDEBUG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] joysticks = Input.GetJoystickNames();
        Debug.Log(joysticks[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("VerticalP1") == 1)
        {
            Debug.Log("p1 up");
        }
        if (Input.GetAxis("VerticalP2") == 1)
        {
            Debug.Log("p2 up");
        }
        if (Input.GetAxis("VerticalP1") == -1)
        {
            Debug.Log("p1 down");
        }
        if (Input.GetAxis("VerticalP2") == -1)
        {
            Debug.Log("p2 down");
        }
        if(Input.GetButton("P1Choose"))
        {
            Debug.Log("p1 chose");
        }
        if(Input.GetButton("P2Choose"))
        {
            Debug.Log("p2 chose");
        }
    }
}
