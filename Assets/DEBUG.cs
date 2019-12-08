using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("P1Choose") > 0)
        {
            Debug.Log("p1 choose");
        }
        if (Input.GetAxis("P2Choose") > 0)
        {
            Debug.Log("p2 choose");
        }

    }
}
