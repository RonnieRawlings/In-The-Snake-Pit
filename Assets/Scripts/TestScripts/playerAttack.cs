// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField]
    public Transform attPoint;
    [SerializeField]
    public LayerMask enemies;

    private float attRange = 0.5f;
    
    public void Attack()
    {
        Collider[] enemiesHit = Physics.OverlapSphere(attPoint.position, attRange, enemies);

        foreach (Collider enemy in enemiesHit)
        {
            Debug.Log("We Hit: " + enemy.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }
}
