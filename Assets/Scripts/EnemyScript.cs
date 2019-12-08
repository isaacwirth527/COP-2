using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyUI;
    public int enemyHealth;
    Slider health;
    public GameObject[] players;
    public int magicDamage;
    public int fightDamage;

    // Start is called before the first frame update
    void Start()
    {
        health = enemyUI.GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        health.value = enemyHealth;
    }


    public void enemyAttack()
    {
        int randomAttack = Random.Range(0, 1);
        if(randomAttack == 0)
        {
            magicAttack();
            Debug.Log("Magic Attack");
        }
        else
        {
            fight();
            Debug.Log("Fight!");
        }
     
    }
   public void magicAttack()
    {
        int randomPlayer = Random.Range(0, 2);
        Debug.Log("Attacked player" + randomPlayer);
        players[randomPlayer].GetComponent<PlayerScript>().playerHealth -= magicDamage;
    }

    public void fight()
    {
        int randomPlayer = Random.Range(0, 2);
        Debug.Log("Attacked player" + randomPlayer);
        players[randomPlayer].GetComponent<PlayerScript>().playerHealth -= fightDamage;
    }

   
}
