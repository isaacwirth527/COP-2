using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class MainMenuManager : MonoBehaviour
{

    public Text TitleText; //text for title

    public Text StartButton;

    public Text DescText; 
    // Start is called before the first frame update
    void Start()
    {
        //StartButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TitleText.text = "";
            StartButton.text = "";
            DescText.text = "Welcome to my twisted mind!";

        }
        
    }

 
}
