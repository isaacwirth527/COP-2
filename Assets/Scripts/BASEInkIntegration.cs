using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class BASEInkIntegration : MonoBehaviour

{
	[SerializeField] private TextAsset _inkJsonAsset;
	[SerializeField] private Story story;
	
	// UI Prefabs
	[SerializeField] private Text textPrefab;
	[SerializeField] private Button buttonPrefab;
	
	
	[SerializeField] private Canvas textCanvas;
	[SerializeField] private Canvas buttonCanvas;

	public InputScript inputScript;
	public bool buttonsExist;

	public GAMEMANAGER gm;
	public Button[] buttons;
	public bool choicesAvailable;
	public bool stopButtonsPlease;
	private void Start()
	{
		stopButtonsPlease = false;
		buttonsExist = false;
		story = new Story(_inkJsonAsset.text);
		RemoveChildren();
		var text = story.Continue();
		if (story.currentChoices.Count > 0)
		{
            for (var i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];

                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });
                button.Select();
				//buttons[i] = button;
            }

        }
		CreateContentView(text);
	}

	private void Update()
	{
		RefreshView();
		if(choicesAvailable)
		{
			for (int i = 0; i < buttons.Length; i++)
			{
				 inputScript.buttons[i] = buttons[i];
			}
		}
	}

	void RefreshView()
	{

        if (!playerInput()) return;
				
		if (story.currentChoices.Count > 0)
		{
			for (var i = 0; i < story.currentChoices.Count; i++)
			{
				if (Input.GetKeyUp((KeyCode) 49 + i))
				{
					story.ChooseChoiceIndex(i);
				}
			}
		}

		if (!story.canContinue) return;

		var text = story.Continue();

		RemoveChildren();

		if (story.currentChoices.Count > 0)
		{
			for (var i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
				button.Select();				
				inputScript.buttons[i] = button;
			}
		}

		CreateContentView(text);
	}
	
	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		RemoveChildren();
		var text = story.Continue();
		var choiceText = "";
		if (story.currentChoices.Count > 0)
		{
			for (var i = 0; i < story.currentChoices.Count; i++) {
				Choice choices = story.currentChoices [i];
				Button button = CreateChoiceView (choices.text.Trim ());
				Debug.Log("Button should be in inspector");
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choices);
				});
				button.Select();
				
			}	
		}
		CreateContentView(text);
	}
	
	void CreateContentView(string text)
	{
		var storyText = Instantiate(textPrefab);
		storyText.text = text;
		storyText.transform.SetParent (textCanvas.transform, false);
	}
	
	    // Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (buttonCanvas.transform, true);
		
		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		// Make the button expand to fit the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;
		choicesAvailable = true;
		buttonsExist = true;
		return choice;
	}
    bool playerInput()
    {

        if (Input.GetButtonUp("P1Choose") && buttonCanvas.gameObject.name == "Left ButtonCanvas")
        {
            Debug.Log("p1 worked");
            return true;

        }
        if (Input.GetButtonUp("P2Choose") && buttonCanvas.gameObject.name == "Right ButtonCanvas")
        {
            Debug.Log("p2 worked");
            return true;

        }
        return false;


    }

    void RemoveChildren () 
	{
		int childCount = textCanvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			Destroy (textCanvas.transform.GetChild (i).gameObject);
		}
		int buttonChildCount = buttonCanvas.transform.childCount;
		for (int i = buttonChildCount - 1; i >= 0; --i) {
			Destroy (buttonCanvas.transform.GetChild (i).gameObject);
		}
		buttonsExist = false;
		choicesAvailable = false;

    }

	public Story GetStory()
	{
		return story;
	}

	public bool AreChoicesAvailable()
	{
		if(!stopButtonsPlease)
		{
			if(choicesAvailable)
			{
				return true;
			}
			else if(!choicesAvailable && !story.canContinue)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		else
		{
			return false;
		}
	
	}

	void PlayerInputManager(Button button1, Button button2)
	{
		if(Input.GetAxis("P2Horizontal") > 0)
		{
			button2.Select();
		}
			if(Input.GetAxis("P2Horizontal") < 0)
		{
			button1.Select();
		}

	}
}