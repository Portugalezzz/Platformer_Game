﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Movable_monster : Monster
{
    [SerializeField]
    private float speed = 6.0F;

    private Vector3 direction;

    private Bullet bullet;

    private SpriteRenderer sprite;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
        
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) RecieveDamage();
            else unit.RecieveDamage();
        }

    }

    protected override void Update()
    {
        move();
    }

    private void move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.55F, 0.01F);
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction.x *= -1.0F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        direction = transform.right;
    }

    // Update is called once per frame

}
