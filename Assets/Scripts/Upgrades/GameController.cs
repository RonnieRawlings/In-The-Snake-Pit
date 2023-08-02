using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //global variables for the amount of upgrades of each of the players statistics have. Each need to be set to 0 at the start of each game.
    //After a selecting an upgrade, the player's statistics should be re-calculated as (base statistics + Constant * upgrades)
    //Feel free to ignore the previous note, it was how I was planning to do them.
    static int attackUpgrades = 0;
    static int healthUpgrades = 0;
    static int speedUpgrades = 0;
    public Upgrades Upgrades;



    public void DamageUp()
    {
        attackUpgrades ++;
        Upgrades.Buff(1);
        //Debug.Log("attack: " + attackUpgrades.ToString());
        //Debug.Log("health: " + healthUpgrades.ToString());
        //Debug.Log("speed: " + speedUpgrades.ToString());
    }
    public void HealthUp()
    {
        healthUpgrades++;
        Upgrades.Buff(0);
        //Debug.Log("attack: " + attackUpgrades.ToString());
        //Debug.Log("health: " + healthUpgrades.ToString());
        //Debug.Log("speed: " + speedUpgrades.ToString());
    }
    public void SpeedUp()
    {
        speedUpgrades++;
        Upgrades.Buff(2);
        //Debug.Log("attack: " + attackUpgrades.ToString());
        //Debug.Log("health: " + healthUpgrades.ToString());
        //Debug.Log("speed: " + speedUpgrades.ToString());
    }
    public int ReturnDamage()
    {
        return attackUpgrades;
    }
    public int ReturnHealth()
    {
        return healthUpgrades;
    }
    public int ReturnSpeed()
    {
        return speedUpgrades;
    }
}
