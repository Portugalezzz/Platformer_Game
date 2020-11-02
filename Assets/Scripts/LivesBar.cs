using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{

    private Transform[] hearts = new Transform[5];
    private Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
        
    }

    public void Refresh()
    {
        for(int i = 0;  i < hearts.Length; i++)
            
            {
            if (i < character.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
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
