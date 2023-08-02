using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFeats : MonoBehaviour
{
    public SwordCombat crystalsUsed;
    public TopDownMovement trapsTriggered;
    public ThumbConditions killCount;
    public PlayerBow arrowsFired;

    public Text killText;
    public Text arrowText;
    public Text crystalText;
    public Text trapText;


    void Update()
    {
        killText.text = "DASHES USED: " + trapsTriggered.timesDashed.ToString();
        arrowText.text = "ARROWS SHOT: " + arrowsFired.fireCount.ToString();
        crystalText.text = "HEALTH CRYSTALS USED: " + crystalsUsed.crystalCount.ToString();
        trapText.text = "TRAPS TRIGGERED: " + trapsTriggered.trapsTriggered.ToString();
    }
}
