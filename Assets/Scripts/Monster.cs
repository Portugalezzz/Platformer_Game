using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    
    public int lives = 2;

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if(bullet)
        {
            RecieveDamage();
            
        }

        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            unit.RecieveDamage();
            //Debug.Log("Damage");
        }
    }

    protected virtual void Awake()
    {
        
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
