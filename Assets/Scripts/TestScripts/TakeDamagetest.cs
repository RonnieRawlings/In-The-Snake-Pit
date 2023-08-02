using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamagetest : MonoBehaviour
{
    public Health targetHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetHealth.takeHealth(1f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            targetHealth.giveHealth(1f);
        }
    }
}
