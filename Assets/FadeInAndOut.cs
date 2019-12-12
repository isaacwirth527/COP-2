using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAndOut : MonoBehaviour
{
    // Start is called before the first frame update
    public float lerpValue;
    public bool fadeIn;
    public bool fadeOut;
    SpriteRenderer spriteRenderer;
    Color opaque;
    void Start()
    {
        fadeOut = true;
        fadeIn = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        opaque = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = opaque;
        if (fadeIn)
        {
            Color lerpColor;
            lerpColor.a = Mathf.Lerp(1, 0, lerpValue);
            opaque.a = lerpColor.a;
        }
           if (fadeOut)
        {
            Color lerpColor;
            lerpColor.a = Mathf.Lerp(0, 1, lerpValue);
            opaque.a = lerpColor.a;
        }
    }
}
