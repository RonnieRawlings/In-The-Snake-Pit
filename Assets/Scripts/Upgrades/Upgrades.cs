using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Ran

public class Upgrades : MonoBehaviour
{
    public float Health;
    public float AttackDamage;
    public float MoveSpeed;
    public Dictionary<string, float> stats = new Dictionary<string, float>();
    Dictionary<int, Upgrade> availableUpgrades = new Dictionary<int, Upgrade>();
    public void Buff(int choice)
    {
        Upgrade chosenUpgrade = availableUpgrades[(choice * 3) + Random.Range(0, 2)];
        stats[chosenUpgrade.upgradable] = stats[chosenUpgrade.upgradable] * chosenUpgrade.upPercent;
    }
    public void Start()
    {
        Health = 100;
        AttackDamage = 10;
        MoveSpeed = 10;
        stats.Add("health", Health);
        stats.Add("attackDamage", AttackDamage);
        stats.Add("moveSpeed", MoveSpeed);
        availableUpgrades.Add(0, new Upgrade("health", 1.25f));
        availableUpgrades.Add(1, new Upgrade("health", 1.5f));
        availableUpgrades.Add(2, new Upgrade("health", 2f));
        availableUpgrades.Add(3, new Upgrade("attackDamage", 1.25f));
        availableUpgrades.Add(4, new Upgrade("attackDamage", 1.5f));
        availableUpgrades.Add(5, new Upgrade("attackDamage", 2f));
        availableUpgrades.Add(6, new Upgrade("moveSpeed", 1.25f));
        availableUpgrades.Add(7, new Upgrade("moveSpeed", 1.5f));
        availableUpgrades.Add(8, new Upgrade("moveSpeed", 2f));
    }
}
public class Upgrade
{
    public string upgradable
    { get; set; }
    public float upPercent
    { get; set; }

    public Upgrade (string upgrdbl, float upprcnt)
    {
        upgradable = upgrdbl;upPercent = upprcnt;
    }
}
