using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private float Speed = 10.0F;

    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    private SpriteRenderer sprite;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.4F);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit.gameObject != parent)
        {
            Destroy(gameObject);
        }
    }
}
