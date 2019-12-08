using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Display.displays.Length > 1)
        {

            // Activate the display 1 (second monitor connected to the system).
            Display.displays[0].Activate();
            Display.displays[1].Activate();
           // Display.displays[0].SetRenderingResolution(1024, 768);
            //Display.displays[1].SetRenderingResolution(800, 600);
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
