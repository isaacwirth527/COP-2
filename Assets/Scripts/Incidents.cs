using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incidents : MonoBehaviour
{
    public GameObject shadyDude;
    public GameObject pizard;
    
/*    four incidents total: the only one in which you fight pizard is when both characters are dishonorable
 
      you fight shady dude in all other incidents */

    public bool p1honor; //p1 warrior
    public bool p2honor; //p2 rogue

        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1honor == true && p2honor == false)
        {
            //fight shady dude 
        }
        if (p1honor == false && p2honor == false)
        {
            //fight pizard 
        }
        if (p1honor == false && p2honor == true)
        {
            //fight shady dude 
        }
        if (p1honor == true && p2honor == true)
        {
            //fight shady dude 
        }
    }
}
