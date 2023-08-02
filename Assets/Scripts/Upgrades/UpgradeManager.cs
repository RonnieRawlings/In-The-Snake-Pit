using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public TopDownMovement moveSpeed;
    public Health health;
    public ArrowTrigger bowDamage;
    public SwordCombat swordDamage;

    public void Start()
    {
        bowDamage = GameObject.Find("Arrow").GetComponent<ArrowTrigger>();
    }
    public void MoveSpeedUp()
    {
        moveSpeed.moveSpeed += 15f;
    }

    public void HealthUp()
    {
        Debug.Log("health called bitch");
        health.baseHealth += health.baseHealth / 5;
        health.currentHealth = health.baseHealth;
    }

    public void DamageUp()
    {
        bowDamage.attDamage += bowDamage.attDamage / 4;
        swordDamage.attackDamage += swordDamage.attackDamage / 4;
    }
}
