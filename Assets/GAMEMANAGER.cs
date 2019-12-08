using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

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
    
	public static int p1Honor, p2Honor, p1Dishonor, p2Dishonor, p1Cunning, p2Cunning, p2Brash, p1Brash;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        p1Honor = storyLeft.EvaluateFunction("honor");
        Debug.Log("p1Honor =" + p1Honor);
        p2Honor = storyRight.EvaluateFunction("honor");
        Debug.Log("p2Honor =" + p2Honor);
        p1Dishonor = storyLeft.EvaluateFunction("dishonor");
        p2Dishonor = storyRight.EvaluateFunction("dishonor");
        p1Cunning = storyLeft.EvaluateFunction("cunning");
        p2Cunning = storyRight.EvaluateFunction("cunning");
        p1Brash = storyRight.EvaluateFunction("brash");
        p2Brash = storyLeft.EvaluateFunction("brash");
    }

    void SceneCheck()
    {

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

    public bool distract()
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

    public bool disarm()
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
