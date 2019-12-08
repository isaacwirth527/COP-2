using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class SpriteManager : MonoBehaviour { 

    public GameObject player1;
    public GameObject player2;

    public Story rightStory;
    public Story LeftStory; 

    public Sprite Mac; 


    // Start is called before the first frame update
    void Start()
    {
        rightStory = player2.GetComponent<BASEInkIntegration>().GetStory();
        LeftStory = player1.GetComponent<BASEInkIntegration>().GetStory(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateContentView(string text)
    {
        var storyText = Instantiate(textPrefab);
        var storyImage = Instantiate(imagePrefab);
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
        storyImage.transform.SetParent(canvas.transform, false);


        storyText.text = text;
    }
}
