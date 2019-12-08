using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class SM : MonoBehaviour 
{ 

    public GameObject player1;
    public GameObject player2;

    public Story rightStory;
    public Story LeftStory; 

    public Sprite Mac;
    public Sprite RandomGuard;
    public Sprite Hurley;
    public Sprite Kraglin;
    public Sprite Pizard; 
    public Sprite RandomNPC;
    public Sprite SleepingLord;
    public Sprite ShadyGuy;
    public Sprite Teller;
    public Sprite Steve; 


    public Sprite Rogue;
    public Sprite Warrior; 

    public TextMesh textPrefab;
    public Sprite imagePrefab;

    public Canvas textCanvas;
    public Canvas imageCanvas;

    // Start is called before the first frame update
    void Start()
    {
        rightStory = player2.GetComponent<BASEInkIntegration>().GetStory();
        LeftStory = player1.GetComponent<BASEInkIntegration>().GetStory(); 
    }
    public void CreateContentView(string text)
    {
        var storyText = Instantiate(textPrefab);
        GameObject storyImageObject = new GameObject();
        storyImageObject.AddComponent<SpriteRenderer>();
        Sprite storyImage = storyImageObject.GetComponent<SpriteRenderer>().sprite;
        storyText.text = text;
        storyText.transform.SetParent(textCanvas.transform, false);
        storyImageObject.transform.SetParent(imageCanvas.transform, false);


        storyText.text = text;

        if (text.Contains("Mac:"))
            {
                 storyImage = Mac; 
            }
        if (text.Contains("Guard:"))
            {
                 storyImage = RandomGuard;
            }
        if (text.Contains("Steve:"))
            {
                 storyImage = Steve; 
            }
        if (text.Contains("Kraglin:"))
            {
                storyImage = Kraglin; 
            }
        if (text.Contains("Hurley:"))
            {
            storyImage = Hurley; 
            }
            
    }
}


