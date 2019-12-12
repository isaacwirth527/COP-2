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

    public bool p1Text;
    public bool p2Text;
    // Start is called before the first frame update
    void Start()
    {
        DescText.text = "Controls: WASD + Space";
        DescText2.text = "Controls: B + Joystick";
        StartButton.Select();
        StartButton2.Select();
        StartButton.enabled = true;
        StartButton2.enabled = false; 
        //StartButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("P1Choose"))
        {
            OnSwitchP1();
        }
        if(Input.GetButton("P2Choose"))
        {
            OnSwitchP2();
        }
        if(p1Text && p2Text)
        {
            StartCoroutine(wait3Sec());
            
        }
    }

    public void OnSwitchP1()
    {
    
    
      TitleText.text = "";
      StartButton.GetComponentInChildren<Text>().text = "";
        //StartButton.SetActive(false);
        StartButton.enabled = false;  
      DescText.text = "Welcome to my twisted mind! I'm so sorry. " +
                      "Anyway my name is, unimportant. Please, choose your class among yourselves." +
                      "Warrior in front of monitor one, Rogue go to monitor two. " +
                      "Or just sit. Don't be a dick about it. " +
                      "You're done with the first part of this game when you can no longer advance" +
                      " And then, well, you'll see won't you? Lastly, don't worry too much if you die in the first part " +
                      " of this game. It is not your end that's important, it's your choices. ";
      p1Text = true;
    
    }

    public void OnSwitchP2()
    {
      TitleText2.text = "";
      StartButton2.GetComponentInChildren<Text>().text = "";
        StartButton2.enabled = false; 
      DescText2.text = "Welcome to my twisted mind! I'm so sorry. " +
                       "Anyway my name is, unimportant. Please, choose your class among yourselves." +
                       "Warrior in front of monitor one, Rogue go to monitor two. " +
                       "Or just sit. Don't be a dick about it. " +
                       "You're done with the first part of this game when you can no longer advance" +
                       " And then, well, you'll see won't you? Lastly, don't worry too much if you die in the first part " +
                       " of this game. It is not your end that's important, it's your choices. ";
      p2Text = true;
      
    }

    IEnumerator wait3Sec()
    {
        yield return new WaitForSeconds(15.0f);
       // print(WaitForSeconds);
        SceneManager.LoadScene("Inky");
    }

 
}
