using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GAMEMANAGER : MonoBehaviour
{
//public GameObject leftPlayer;
	//public GameObject rightPlayer;
    public bool player1Honor;
    public bool player2Honor;
	public BASEInkIntegration leftInk;
	public BASEInkIntegration rightInk;
    public Story storyLeft;
    public Story storyRight;

    public Button leftButtons;
    
    
	public static int p1Honor, p2Honor, p1Dishonor, p2Dishonor, p1Cunning, p2Cunning, p2Brash, p1Brash;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        p1Honor = (int)storyLeft.variablesState["health"];
        Debug.Log("p1Honor =" + p1Honor);
        p2Honor = (int)storyRight.variablesState["health"];
        Debug.Log("p2Honor =" + p2Honor);
        p1Dishonor = (int)storyLeft.variablesState["dishonor"];
        p2Dishonor = (int)storyRight.variablesState["dishonor"];
        p1Cunning = (int)storyLeft.variablesState["cunning"];
        p2Cunning = (int)storyRight.variablesState["cunning"];
        p1Brash = (int)storyLeft.variablesState["brash"];
        p2Brash = (int)storyRight.variablesState["brash"];
    }

    void SceneCheck()
    {
         if(p1DetermineHonor() == p2DetermineHonor())
        {
            SceneManager.LoadScene("Cutscene1");

        }
         if(!p1DetermineHonor() == !p2DetermineHonor())
        {
            SceneManager.LoadScene("Cutscene2");

        }
         if(p1DetermineHonor() && !p2DetermineHonor())
        {
            SceneManager.LoadScene("Cutscene3");

        }
         if(!p1DetermineHonor() && p2DetermineHonor())
        {
            SceneManager.LoadScene("Cutscene4");

        }

    }

    void SceneChange()
    {

    }

    void DetermineAttack()
    {
    	leftPlayerAttacks.Add(sneakAttack());

    	if (brash >= cunning)
    	{

    	}
    }

   
    public int sneakAttack()
    {
        return 20;
    }
    public int stab()
    {
    	return 10;
    }

    public bool dodge()
    {
    	return true;
    }

    public void distract()
    {
    	warriorAdv();
    }

    public int feint()
    {
    	return 15;
    }

    public int standardAttack()
    {
    	return 10;
    }

    public void disarm()
    {
    	rogueAdv();
    }

    public int goLow()
	{
		warriorAdv();
		return 15;
    }

    public int knifeThrow()
    {
    	int randomInt = Random.Range(0, 2);
    		if(randomInt == 1)
    		{
    			return 15;
    		}
    		else
    		{
    			enemyAdv();
    			return 0;
    		}
    }

    public int charge()
    {
    	return 15;
    }

    public int goHigh()
    {
    	rogueAdv();
    	return 15;
    }

    public void rogueAdv()
    {
    	//true;
    }

    public void warriorAdv()
    {
    	//true;
    }

    public void enemyAdv()
    {
    	//true;
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

 