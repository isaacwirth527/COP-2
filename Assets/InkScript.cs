using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkScript : MonoBehaviour
{
    // Set this file to your compiled json asset
    public TextAsset inkAsset;

    // The ink story that we're wrapping
    Story _inkStory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        _inkStory = new Story(inkAsset.text);
    }

     void Update()
    {
        while (_inkStory.canContinue)
        {
            Debug.Log(_inkStory.Continue());
        }
    }
}

