﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class GAMEMANAGER : MonoBehaviour
{
    public GameObject RPGfight;
    public GameObject twoStories;

    public GameObject leftPlayerRPG;
	public GameObject rightPlayerRPG;
    public bool player1Honor;
    public bool player2Honor;
    public EnemyScript enemyScript;
	public BASEInkIntegration leftInk;
	public BASEInkIntegration rightInk;
    public TextAsset JSONLeft;
    public TextAsset JSONRight;
    
    public Button buttonPrefabL1, buttonPrefabL2, buttonPrefabL3, buttonPrefabR1, buttonPrefabR2, buttonPrefabR3;
    public bool switchScene;
    private Story storyLeft;
    private Story storyRight;
    public bool round1;
    public bool rogueDodge;
    public bool rogueAdv;
    public bool warriorAdv;
    public bool enemyAdv;
    public GameObject enemyObject;
    public GameObject[] LeftHonorOutcomes;
    public GameObject[] RightHonorOutcomes;
    public PlayerScript playerLeftScript;
    public PlayerScript playerRightScript;
    public bool sceneChanged;

    public GameObject pizard;
    public GameObject shadyGuy;
    public GameObject pizardClone;
    public GameObject shadyGuyClone;
    public bool pizardOn;
    public bool RPGFightTime;
    public Slider leftEnemyHealth;
    public Slider rightEnemyHealth;
    public AudioSource novelMusic;
    public AudioSource fightMusic;
    BASEInkIntegration currentLeftStory;
    BASEInkIntegration currentRightStory;
    
	public int p1Honor, p2Honor, p1Dishonor, p2Dishonor, p1Cunning, p2Cunning, p2Brash, p1Brash;

    // Start is called before the first frame update
    void Start()
    {
        //p1Honor = 5;
        RPGFightTime = false;
        currentLeftStory = leftInk;
        currentRightStory = rightInk;
        enemyObject = shadyGuy;
        sceneChanged = false;
        RPGfight.SetActive(false);
        playerRightScript = rightPlayerRPG.GetComponent<PlayerScript>();
        playerLeftScript = leftPlayerRPG.GetComponent<PlayerScript>();
        controlRPGButtons(false);
        pizardOn = false;
        pizardClone.gameObject.SetActive(false);
        shadyGuyClone.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(leftInk.AreChoicesAvailable() && rightInk.AreChoicesAvailable())
        
        p1Honor = (int)leftInk.story.variablesState["honor"];
        Debug.Log(p1Honor);
        p2Honor = (int)rightInk.story.variablesState["honor"];
        Debug.Log("p2Honor =" + p2Honor);
        p1Dishonor = (int)leftInk.story.variablesState["dishonor"];
        p2Dishonor = (int)rightInk.story.variablesState["dishonor"];
        p1Cunning = (int)leftInk.story.variablesState["cunning"];
        p2Cunning = (int)rightInk.story.variablesState["cunning"];
        p1Brash = (int)leftInk.story.variablesState["brash"];
        p2Brash = (int)rightInk.story.variablesState["brash"];
        

       if(!leftInk.AreChoicesAvailable() && !rightInk.AreChoicesAvailable()&& !sceneChanged)
          {
               RPGNarrativeSwitch();
          }  

         if(!currentLeftStory.AreChoicesAvailable() && !currentRightStory.AreChoicesAvailable() && !sceneChanged)
         {
            SceneChange();
            DetermineAttackP1();
            DetermineAttackP2();
            controlRPGButtons(true);
            RPGFightTime = true;
            rightEnemyHealth.value = leftEnemyHealth.value;
            novelMusic.gameObject.SetActive(false);
            fightMusic.gameObject.SetActive(true);
            
         }
       
    }

    public bool RPGNarrativeSwitch()
    {
       
        if(!sceneChanged)
        {
           leftInk.gameObject.SetActive(false);
           rightInk.gameObject.SetActive(false);

            if(p1DetermineHonor() && p2DetermineHonor() )
            {
                LeftHonorOutcomes[0].SetActive(true);
                RightHonorOutcomes[0].SetActive(true);
                currentLeftStory = LeftHonorOutcomes[0].GetComponent<BASEInkIntegration>();
                currentRightStory = RightHonorOutcomes[0].GetComponent<BASEInkIntegration>();
                Debug.Log("Honorable");
            }
             if(!p1DetermineHonor() && p2DetermineHonor() )
            {
                LeftHonorOutcomes[1].SetActive(true);
                RightHonorOutcomes[1].SetActive(true);
                currentLeftStory = LeftHonorOutcomes[1].GetComponent<BASEInkIntegration>();
                currentRightStory = RightHonorOutcomes[1].GetComponent<BASEInkIntegration>();
                Debug.Log("Not Honorable" + "Honorable");
            }
              if(!p1DetermineHonor() && !p2DetermineHonor() )
            {
                LeftHonorOutcomes[2].SetActive(true);
                RightHonorOutcomes[2].SetActive(true);
                currentLeftStory = LeftHonorOutcomes[2].GetComponent<BASEInkIntegration>();
                currentRightStory = RightHonorOutcomes[2].GetComponent<BASEInkIntegration>();
                pizardOn = true;
                Debug.Log("Not Honorable");
            }
              if(p1DetermineHonor() && !p2DetermineHonor() )
            {
                LeftHonorOutcomes[3].SetActive(true);
                RightHonorOutcomes[3].SetActive(true);
                currentLeftStory = LeftHonorOutcomes[3].GetComponent<BASEInkIntegration>();
                currentRightStory = RightHonorOutcomes[3].GetComponent<BASEInkIntegration>();
                Debug.Log("Not Honorable" + "Not Honorable");
            }
            switchScene = true;
            Debug.Log("scene changed");
            return true;

            
        }
        else
        {
            Debug.Log("rpgnarrativeswitchfalse");
            return false;

        }

       
    }
    void SceneChange()
    
    {
        
        twoStories.SetActive(false);
        RPGfight.SetActive(true);
        sceneChanged = true;
           if(pizardOn == true)
            {
               enemyObject = pizard;
               pizard.SetActive(true);
               pizardClone.SetActive(true);

            }
            else
            {
                enemyObject = shadyGuy;
                shadyGuy.SetActive(true);
                shadyGuyClone.SetActive(true);
            }
    }
        




   
    public Button sneakAttack(Button newButton)
    {  
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sneak Attack";
        newButton.onClick.AddListener(()=>damageR(20f));
        return newButton;
    }
  
    public Button stab(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Stab";
        newButton.onClick.AddListener(()=>damageR(10f));
        return newButton;
    }

    public Button dodge(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Dodge";
        newButton.onClick.AddListener(()=>damageR(0f));
        newButton.onClick.AddListener(setDodge);
        return newButton;
    }

    public Button distract(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Distract";
        newButton.onClick.AddListener(()=>damageR(0f));
        newButton.onClick.AddListener(setWarriorAdv);
        return newButton;
    }

    public Button feint(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Feint";
        newButton.onClick.AddListener(()=>damageW(15f));
        return newButton;
    }

    public Button standardAttack(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Attack";
        newButton.onClick.AddListener(()=>damageW(10f));
        return newButton;
    }

    public Button disarm(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Distract";
        newButton.onClick.AddListener(()=>damageW(0f));
        newButton.onClick.AddListener(setRogueAdv);
        return newButton;
    }

     public Button goLow(Button newButton)
	 {
         newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Go Low";
        newButton.onClick.AddListener(()=>damageR(15f));
         newButton.onClick.AddListener(setWarriorAdv);
        return newButton;
     }

    public Button knifeThrow(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Throw Knife";
    	int randomInt = Random.Range(0, 2);
    		if(randomInt == 1)
    		{
    		    newButton.onClick.AddListener(()=>damageR(15f));
                newButton.onClick.AddListener(setWarriorAdv);
    		}
    		else
    		{
                newButton.onClick.AddListener(()=>damageR(0));
    		}
            return newButton;
    }

    public Button charge(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Charge";
        newButton.onClick.AddListener(()=>damageW(15f));
        return newButton;
    }

    public Button goHigh(Button newButton)
    {
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Go High";
        newButton.onClick.AddListener(()=>damageW(15f));
        newButton.onClick.AddListener(setRogueAdv);
        return newButton;

    }

    void damageR(float damage)
    {
        Debug.Log(damage);
        if (rogueAdv)
        {
            playerLeftScript.adv((int)damage);
        }

        enemyObject.GetComponent<EnemyScript>().enemyHealth -= (int)damage;
    }

    void damageW(float damage)
    {
        if (warriorAdv)
        {
            playerRightScript.adv((int)damage);
        }
        enemyObject.GetComponent<EnemyScript>().enemyHealth -= (int)damage;
    }
    
    public void setDodge()
    {
        rogueDodge = true;
    }
    public void setRogueAdv()
    {
        rogueAdv = true;
    }
       public void setWarriorAdv()
    {
        warriorAdv = true;
    }

    public bool p1DetermineHonor()
    {
        if (p1Honor >= p1Dishonor)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool p2DetermineHonor()
    {
      if (p2Honor >= p2Dishonor)
        {
            return true;
        }
     else
        {
            return false;
        }
  
    }
        public void DetermineAttackP1()
    {
        if (p1Cunning > p1Brash)
        {
            
            if(round1)
            {
                sneakAttack(buttonPrefabL1);
            }
            else
            {
               stab(buttonPrefabL1);
            }
           dodge(buttonPrefabL2);
           distract(buttonPrefabL3);
        }
        else
        {
            goLow(buttonPrefabL1);
            standardAttack(buttonPrefabL2);
            knifeThrow(buttonPrefabL3);
                    
         }
    }
       public void DetermineAttackP2()
    {
        if (p2Cunning > p2Brash)
        {
            feint(buttonPrefabR1);
            standardAttack(buttonPrefabR2);
            disarm(buttonPrefabR3);
        }
        else
        {
            charge(buttonPrefabR1);
            standardAttack(buttonPrefabR2);
            goHigh(buttonPrefabR3);
                    
         }
    }

    public void controlRPGButtons(bool active)
    {
     
            
            buttonPrefabL1.gameObject.SetActive(active);
            buttonPrefabL2.gameObject.SetActive(active);
            buttonPrefabL3.gameObject.SetActive(active);
            buttonPrefabR1.gameObject.SetActive(active);
            buttonPrefabR2.gameObject.SetActive(active);
            buttonPrefabR3.gameObject.SetActive(active);
       
    }
}

 