using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;
using UnityEngine.SceneManagement;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkIntegrationRight : MonoBehaviour
{
	private int count;
	
	[SerializeField] private TextAsset _inkJsonAsset;
	[SerializeField] private Story story;
	
	// UI Prefabs
	[SerializeField] private Text textPrefab;
	[SerializeField] private Button buttonPrefab;
	
	
	[SerializeField] private Canvas TextCanvas;
	[SerializeField] private Canvas ButtonCanvas;

	// Remove the default 
	// Creates a new Story object with the compiled story which we can then play!

	private void Start()
	{
		story = new Story(_inkJsonAsset.text);
		RemoveChildren();
		var text = story.Continue();
		if (story.currentChoices.Count > 0)
		{
			for (var i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		CreateContentView(text);
	}

	private void Update()
	{
		RefreshView();
	}

	void RefreshView(){
		
		if (Input.GetKey(KeyCode.Space) || Input.GetAxis("P2Choose") == 0) return;
				
		if (story.currentChoices.Count > 0)
		{
			for (var i = 0; i < story.currentChoices.Count; i++)
			{
				if (Input.GetKeyDown((KeyCode) 49 + i))
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
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choices);
				});
			}
		}
		CreateContentView(text);
	}
	
	void CreateContentView(string text)
	{
		var storyText = Instantiate(textPrefab);
		storyText.text = text;
		storyText.transform.SetParent (TextCanvas.transform, false);
	}
	
	    // Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (ButtonCanvas.transform, true);
		
		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		// Make the button expand to fit the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;
	
		return choice;
	}
	
	void RemoveChildren () {
		int childCount = TextCanvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			Destroy (TextCanvas.transform.GetChild (i).gameObject);
		}
		int buttonChildCount = ButtonCanvas.transform.childCount;
		for (int i = buttonChildCount - 1; i >= 0; --i) {
			Destroy (ButtonCanvas.transform.GetChild (i).gameObject);
		}
	}
}