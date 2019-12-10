using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manage : MonoBehaviour
{
    public GameObject enemy;
    public PlayerScript player1;
    public PlayerScript player2;
    bool chosen1;
    bool chosen2;
    public int turnCounter;
    public GameObject p1Choose;
    public GameObject  p2Choose;
    public Animator p1Animator;
    public Animator p2Animator;
    


    // Start is called before the first frame update
    void Start()
    {
        p1Animator.Play("SpriteFadeIn1");
        p2Animator.Play("SpriteFadeIn2");
    }

    // Update is called once per frame
    void Update()
    {
        chosen1 = player1.choose;
        chosen2 = player2.choose;

        if (chosen1 == false && chosen2 == false)
        {
            p1Animator.Play("SpriteFade1");
            p1Animator.Play("Player1TurnStart");
            p2Animator.Play("SpriteFadeOut2");
            p2Animator.Play("Player2Turn");

        }
        if(chosen1 && !chosen2)
        {
            p2Animator.Play("SpriteFadeIn2");
            p2Animator.Play("Player2TurnStart");
            p1Animator.Play("SpriteFadeOut1");
            p1Animator.Play("Player1Turn");
            player1.gameObject.SetActive(false);

        }



        if (chosen1 == chosen2 && chosen2 == true )
        {
            player2.gameObject.SetActive(false);
            enemy.GetComponent<EnemyScript>().enemyAttack();
            Debug.Log("Enemy attacked!");
            Debug.Log("Waiting");
            
            //StartCoroutine(waitFalse());
            SetBothFalse();
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(true);

        }
    }
    IEnumerator waitFalse()
    {
        
        yield return new WaitForSeconds(3.0f);
        
    }
    void SetBothFalse()
    {
        player1.GetComponent<PlayerScript>().setChoseFalse();
        player2.GetComponent<PlayerScript>().setChoseFalse();
    }
}
