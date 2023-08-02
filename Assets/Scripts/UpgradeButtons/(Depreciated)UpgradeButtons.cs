using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    public void incrementStatics()//So, this should run when any of the buttons are clicked. It'll find the text of the button and increment the right static depending on the button clicked
    {
        string buttonName = this.GetComponent<Text>().ToString();
        //switch (buttonName)
        //{
        //    case = "":
        //            //increment damage
        //            Debug.Log("Damage upgraded");
        //            break;
        //    case == "":
        //            //increment health
        //            Debug.Log("Health upgraded");
        //        break;
        //    case == "":
        //            //increment speed
        //            Debug.Log("Speed upgraded");
        //        break;
        //}

        if (buttonName == "DamageButton")
        {
            //increment damage
            Debug.Log("Damage upgraded");
        }
        else if(buttonName == "HealthButton")
        {
            //increment health
            Debug.Log("Health upgraded");
        }
        else if(buttonName == "DamageButton")
        {
            //increment speed
            Debug.Log("Speed upgraded");
        }
    }
}
