using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Ink.Runtime;
using UnityEngine.SceneManagement;


// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkIntegration : MonoBehaviour
{
	private int count;
    private bool input;

    bool leftButtonClicked;
    bool rightButtonClicked;

	[SerializeField] private TextAsset _inkJsonAsset;
	[SerializeField] private Story story;
	
	// UI Prefabs
	[SerializeField] private Text textPrefab;
	//[SerializeField] private Button buttonPrefab;
	
	
	[SerializeField] private Canvas TextCanvas;
	[SerializeField] private Canvas ButtonCanvas;

    public  Button choice1;
    public Button choice2;

    string text;
    int currentChoiceIndex;

    bool isSelectedR;
    bool isSelectedL;
    // Remove the default 
    // Creates a new Story object with the compiled story which we can then play!

    private void Start()
	{
		story = new Story(_inkJsonAsset.text);
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
	    text = story.Continue();
		if (story.currentChoices.Count > 0)
		{
			for (var i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
                Choice choice2 = story.currentChoices[i+1];
				Button[] buttons = CreateChoiceView (choice.text.Trim(), choice2.text.Trim());
//Tell the button what to do when we press it
				buttons[0].onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
            buttons[1].onClick.AddListener(delegate {
              OnClickChoiceButton(choice2);
            });
            }
		}
		CreateContentView(text);
	}

    private void Update()
    {
        input = playerInput();
        if (playerInput())
        {
            RefreshView();
        }

        if (horizontal() ==1)
        {   Debug.Log("right");
            choice2.Select();
            isSelectedR = true;
            isSelectedL = false;
        }
        if (horizontal() == 0)
        {
            if(isSelectedR)
            {
                choice2.Select();
            }
            if(isSelectedL)
            {
                choice1.Select();
            }
        }
        if (horizontal() ==-1)
        {
            Debug.Log("left");
            choice1.Select();
            isSelectedR = false;
            isSelectedL = true;
        }

        
    }

 

	void RefreshView(){
		
		if (!input) return;

	    if (story.currentChoices.Count > 0)
		{
			for (var i = 0; i < story.currentChoices.Count; i++)
			{
                if (playerInput())
                {
                    story.ChooseChoiceIndex(i);
                }

			}
		}

  

    

        if (!story.canContinue)
        {
            Debug.Log("CANT CONTINUE");
            return;
        }

        var text = story.Continue();        
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        //RemoveListeners(choice1);
        //RemoveListeners(choice2);
        RemoveChildren();
        CreateContentView(text);

        if (story.currentChoices.Count > 0)
        {
            for (var i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Choice choice2 = story.currentChoices[i+1];
                Button[] buttons = CreateChoiceView(choice.text.Trim(), choice2.text.Trim());
                //// Tell the button what to do when we press it
              buttons[0].onClick.AddListener(delegate {
                 OnClickChoiceButton(choice);
               });
              buttons[1].onClick.AddListener(delegate {
                 OnClickChoiceButton(choice2);
              });
            }
        }

        CreateContentView(text);
	}
	
	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);

        RefreshView();
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        //RemoveListeners(choice1);
        //RemoveListeners(choice2);
        RemoveChildren();
       // var text = story.Continue();
		//var choiceText = "";


    
        












  //      if (story.currentChoices.Count > 0)
		//{
		//	for (var i = 0; i < story.currentChoices.Count; i++) {
		//		Choice choices = story.currentChoices[i];
  //              Choice choices2 = story.currentChoices[i+1];
  //              Button[] buttons = CreateChoiceView(choices.text.Trim(), choices2.text.Trim());
		//		buttons[0].onClick.AddListener (delegate {
		//			OnClickChoiceButton (choices);
		//		});
  //             buttons[1].onClick.AddListener(delegate {
  //                 OnClickChoiceButton(choices2);
  //             });
  //          }
		//}
		CreateContentView(text);
	}
	
	void CreateContentView(string text)
	{
		var storyText = Instantiate(textPrefab);
		storyText.text = text;
		storyText.transform.SetParent (TextCanvas.transform, false);
	}

	
	    // Creates a button showing the choice text
	Button[] CreateChoiceView (string textHere, string textHere2) {
        // Creates the button from a prefab
        //Button choice = Instantiate (buttonPrefab) as Button;
        //choice1.transform.SetParent (ButtonCanvas.transform, true);
        //choice2.transform.SetParent(ButtonCanvas.transform, true);
        choice1.gameObject.SetActive(true);
        choice2.gameObject.SetActive(true);
        TextMeshProUGUI choiceTextMesh = choice1.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI choiceTextMesh2 = choice2.GetComponentInChildren<TextMeshProUGUI>();
       
        Debug.Log(textHere);
        Debug.Log(textHere2);

        string fuck = textHere;
        string fuck2 = textHere2;
     

        choiceTextMesh.text = fuck;
        choiceTextMesh2.text = fuck2;
        // Gets the text from the button prefab
        //string choiceText;
        //choiceText = choice1.GetComponentInChildren<Text>().ToString() ;
        // string choiceText2;
        // choiceText2= choice2.GetComponentInChildren<Text>().ToString();
        //choiceText = text.ToString();
        // choiceText2 = text2.ToString();


        // Make the button expand to fit the text
        HorizontalLayoutGroup layoutGroup = ButtonCanvas.GetComponent<HorizontalLayoutGroup>();
		layoutGroup.childForceExpandHeight = true;
        Button[] buttons = new Button[2];
        buttons[0] = choice1;
        buttons[1] = choice2;
        return buttons;
	}
	
	void RemoveChildren () {
		int childCount = TextCanvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			Destroy (TextCanvas.transform.GetChild (i).gameObject);
		}
	}

    bool playerInput()
    {
        //EventType buttonPress = Event.current.type;
        //if (buttonPress == EventType.KeyUp)
        //{
        //    return true;
        //}
        //else()
        //{
        //    return false;
        //}

        if(Input.GetButtonUp("P1Choose") && ButtonCanvas.gameObject.name == "Left ButtonCanvas")
        {
            Debug.Log("p1 worked");
            return true;
            
        }
        if(Input.GetButtonUp("P2Choose") && ButtonCanvas.gameObject.name == "Right ButtonCanvas")
        {
            Debug.Log("p2 worked");
            return true;
            
        }
        return false;

     
    }

    float horizontal()
    {
        float i = Input.GetAxis("HorizontalP2");
        return i;
    }

    //void getChoice(Button[] buttons, Choice[] choices)
    //{
    //    if (buttons[0].onClick)
    //    {
    //        OnClickChoiceButton(choices[0]);
    //    }
    //}
    //public static void RemoveListeners(Button button)
    //{
    //    //button.onClick.RemoveListener(call);
    //    button.onClick.RemoveAllListeners();
    //}



}