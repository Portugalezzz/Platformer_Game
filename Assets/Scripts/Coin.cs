using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Unit
{
    public bool shine = false;
    private Animator animator;
    private float delay;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("Shine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shine()
    {
        for (; ; )
        {
            if(shine) delay = 4;
            else delay = 1;
            shine = !shine;
            Debug.Log("Anim " + shine);
            animator.SetBool("Shining", shine);
            yield return new WaitForSeconds(delay);
            
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            Destroy(gameObject);
            unit.AddCoin();
            //Debug.Log("Damage");
        }
    }
}
