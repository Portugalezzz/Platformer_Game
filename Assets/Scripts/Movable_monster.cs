using System.Collections;
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
        lives = 2;
        
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();




        if (unit && unit is Character)
        {
            //Debug.Log("TOUCH");
            //  Debug.Log("ABS  " + Mathf.Abs(unit.transform.position.x - transform.position.x));
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.8F)
            {
                ((Character)unit).Jump();
                RecieveDamage();

              //  Debug.Log("Jump");
            }
            else if (!Character.damaged) unit.RecieveDamage();
        }

    }

    protected override void Update()
    {
        move();
    }

    private void move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.55F, 0.01F);
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())&& colliders.All(x => !x.GetComponent<Coin>())) direction.x *= -1.0F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        direction = transform.right;
        
        if (Random.value < 0.5 )
        {
            direction *= -1;
        }
            


    }

    // Update is called once per frame

    public override void RecieveDamage()
    {
        base.RecieveDamage();
      //  Debug.Log("MonsterHealth_MONSTER: " + lives);
    }
}
