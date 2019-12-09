using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    public Canvas p1Canvas;
    public Canvas p2Canvas;
   public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = new Button[2];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("HorizontalP2") > 0)
        {
            Debug.Log("itsWorking");
            if(p2Canvas.transform.childCount > 0)
            {
                Debug.Log("itsWorking");
                buttons[1].Select();
            }
        }
         if(Input.GetAxis("HorizontalP2") < 0)
        {
            if(p2Canvas.transform.childCount > 0)
            {
                Debug.Log("itsWorking");
                buttons[0].Select();
                
            }
        }
        if(Input.GetButtonUp("P2Choose"))
        {
            Debug.Log("SUBMIT");
        }
    }
}
