using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using TMPro;

public class MainMenuManager : MonoBehaviour
{

    public Text TitleText; //text for title
    public Text TitleText2;
    public Button StartButton;
    public Button StartButton2;
    public TextMeshProUGUI DescText; 
    public TextMeshProUGUI DescText2;
    // Start is called before the first frame update
    void Start()
    {
        DescText.text = "";
        DescText2.text = "";
        StartButton.Select();
        StartButton2.Select();
        //StartButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwitch()
    {
      TitleText.text = "";
      TitleText2.text = "";
      StartButton.GetComponentInChildren<Text>().text = "";
      StartButton2.GetComponentInChildren<Text>().text = "";
      DescText.text = "Welcome to my twisted mind!";
      DescText2.text = "Welcome to my twisted mind!";

    }

 
}
