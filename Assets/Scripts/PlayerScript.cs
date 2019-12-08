using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject playerUI;
    public int playerHealth;
    public GameObject enemy;
    public int magicAttackDamage;
    public int meleeAttackDamage;

    public Button[] playerButtons;

    public bool choose;

    int enemyHealth;
    public Slider health;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        enemyHealth = enemy.GetComponent<EnemyScript>().enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.value = playerHealth;
    }

    // public void magicAttack1()
    // {
    //     enemyHealth -= magicAttackDamage;
    //     Debug.Log("Enemy took " + magicAttackDamage + "damage.");
    // }

    // public void fight()
    // {
    //     enemyHealth -= meleeAttackDamage;
    //     Debug.Log("Enemy took " + meleeAttackDamage + "damage.");
    // }

    // public void run()
    // {
    //     Debug.Log("Can't escape!");
    // }

    public void setChoseFalse()
    {
        choose = false;
    }

    public void setChoseTrue()
    {
        choose = true;
    }

    public int adv(int i)
    {
        return i*2;
    }
    
}
