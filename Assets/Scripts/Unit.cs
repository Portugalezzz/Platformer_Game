using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    int lives;
    public virtual void RecieveDamage()
    {
        lives --;
        Debug.Log("MonsterHealth: " + lives);
        if (lives<=0)
        {
            Die();
            Debug.Log("MonsterKill" + lives);
        }
            
    }
    
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
