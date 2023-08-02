using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthDisplay : MonoBehaviour
{
    public Health health;
    public TextMesh display;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display.text = Convert.ToString(health.getHealth());
    }
}
