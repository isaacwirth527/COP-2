using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GAMEMANAGER gm;
    public AudioClip RPGFightMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        gm = GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>();
        if(gm.RPGFightTime)
        {
            this.GetComponent<AudioSource>().clip = RPGFightMusic;
            this.GetComponent<AudioSource>().Play();
        }
    }

    
}
