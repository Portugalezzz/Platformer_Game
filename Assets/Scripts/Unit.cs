using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   // [SerializeField]
    public static int coins;
    public int lives;
    
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

    public void AddCoin()
    {
        coins++;
        
        Debug.Log("Coins " + coins);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    

}
