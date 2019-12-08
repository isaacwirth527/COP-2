using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneScript : MonoBehaviour
{
    public string chooseAxis;
 
   public bool axisChosen()
    {
        if("P1Choose" == chooseAxis)
        {
            if(Input.GetAxis("P1Choose") > 0)
            {
                return true;
            }
            return false;
        }
        if("P2Choose" == chooseAxis)
        {
            if (Input.GetAxis("P2Choose") > 0)
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }

    }


}
