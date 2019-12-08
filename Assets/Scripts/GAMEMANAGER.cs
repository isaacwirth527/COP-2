using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
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
    public Story storyLeft;
    public Story storyRight;
    public Button buttonPrefab;
    
    public bool round1;
    public bool rogueDodge;
    public bool rogueAdv;
    public bool warriorAdv;
    public bool enemyAdv;
    public EnemyScript enemy;

    public PlayerScript playerLeftScript;
    public PlayerScript playerRightScript;

    public Button[] playerLeftButtons;
    public Button[] playerRightButtons;
    
	public static int p1Honor, p2Honor, p1Dishonor, p2Dishonor, p1Cunning, p2Cunning, p2Brash, p1Brash;

    // Start is called before the first frame update
    void Start()
    {
        storyLeft = leftInk.GetComponent<BASEInkIntegration>().GetStory();
        storyRight = rightInk.GetComponent<BASEInkIntegration>().GetStory();
        RPGfight.SetActive(false);
        playerRightScript = rightPlayerRPG.GetComponent<PlayerScript>();
        playerLeftScript = leftPlayerRPG.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        p1Honor = (int)storyLeft.variablesState["honor"];
        Debug.Log("p1Honor =" + p1Honor);
        p2Honor = (int)storyRight.variablesState["honor"];
        Debug.Log("p2Honor =" + p2Honor);
        p1Dishonor = (int)storyLeft.variablesState["dishonor"];
        p2Dishonor = (int)storyRight.variablesState["dishonor"];
        p1Cunning = (int)storyLeft.variablesState["cunning"];
        p2Cunning = (int)storyRight.variablesState["cunning"];
        p1Brash = (int)storyLeft.variablesState["brash"];
        p2Brash = (int)storyRight.variablesState["brash"];

        if(!storyLeft.canContinue == storyRight.canContinue)
        {
            SceneChange();
            DetermineAttackP1();
            DetermineAttackP2();
        }
    }

    void SceneChange()
    {
        twoStories.SetActive(false);
        RPGfight.SetActive(true);

    }

    void DetermineAttackP1()
    {
        if (p1Cunning > p1Brash)
        {
            if(round1)
            {
                sneakAttack();
            }
            else
            {
                stab();
            }
            dodge();
            distract();
        }
        else
        {
            goLow();
            standardAttack();
            knifeThrow();
                    
         }
    }
        void DetermineAttackP2()
    {
        if (p2Cunning > p2Brash)
        {
            feint();
            standardAttack();
            disarm();
        }
        else
        {
            charge();
            standardAttack();
            goHigh();
                    
         }
    }

   
    public Button sneakAttack()
    {   Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sneak Attack";
        newButton.onClick.AddListener(()=>damageR(20));
        return newButton;
    }
  
    public Button stab()
    {
    	Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Stab";
        newButton.onClick.AddListener(()=>damageR(10));
        return newButton;
    }

    public Button dodge()
    {
        
    	Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Dodge";
        newButton.onClick.AddListener(()=>damageR(0));
        newButton.onClick.AddListener(setDodge);
        return newButton;
    }

    public Button distract()
    {
    	Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Distract";
        newButton.onClick.AddListener(()=>damageR(0));
        newButton.onClick.AddListener(setWarriorAdv);
        return newButton;
    }

    public Button feint()
    {
        Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Feint";
        newButton.onClick.AddListener(()=>damageW(15));
        return newButton;
    }

    public bool standardAttack()
    {
        Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Attack";
        newButton.onClick.AddListener(()=>damageW(10));
        return newButton;
    }

    public Button disarm()
    {
        Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Distract";
        newButton.onClick.AddListener(()=>damageW(0));
        newButton.onClick.AddListener(setRogueAdv);
        return newButton;
    }

    public Button goLow()
	{
        Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Go Low";
        newButton.onClick.AddListener(()=>damageR(15));
        newButton.onClick.AddListener(setWarriorAdv);
        return newButton;
    }

    public Button knifeThrow()
    {
        Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Throw Knife";
    	int randomInt = Random.Range(0, 2);
    		if(randomInt == 1)
    		{
    		    newButton.onClick.AddListener(()=>damageR(15));
                newButton.onClick.AddListener(setWarriorAdv);
    		}
    		else
    		{
                newButton.onClick.AddListener(()=>damageR(0));
    		}
            return newButton;
    }

    public Button charge()
    {
    	Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Charge";
        newButton.onClick.AddListener(()=>damageW(15));
        return newButton;
    }

    public Button goHigh()
    {
    	Button newButton = Instantiate(buttonPrefab);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Go High";
        newButton.onClick.AddListener(()=>damageW(15));
        newButton.onClick.AddListener(setRogueAdv);
        return newButton;

    }

    int damageR(int damage)
    {
        if (rogueAdv)
        {
            playerLeftScript.adv(damage);
        }

        return damage;
    }

    int damageW(int damage)
    {
        if (warriorAdv)
        {
            playerRightScript.adv(damage);
        }
        return damage;
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
}

 