using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    [SerializeField]
    private float speed = 3.0F;
    // [SerializeField]
    // private int lives = 5;
    [SerializeField]
    private float freeze = 0.5F;
    public static bool squat = false;
    public static bool damaged = false;
    private float jumpforce = 15.0F;

    private bool isGrounded = false;
    
    private Bullet bullet;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    private CharState State
    {
        get {return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;


    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        bullet = Resources.Load<Bullet>("Bullet");
    }


    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed* Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        if (isGrounded) State = CharState.Run;
    }

    
    public void Jump()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        
        
    }
    
    
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;
        if (!isGrounded) State = CharState.Jump;
    }


    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.8F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }



    public override void RecieveDamage()
    {
        Lives --;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 5.0F, ForceMode2D.Impulse);
        rigidbody.AddForce(transform.right * -4.0F, ForceMode2D.Impulse);
        damaged = true;
        StartCoroutine(DamageFreeze(freeze));


        Debug.Log(lives);
    }




    IEnumerator DamageFreeze(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        damaged = false;
        yield break;
    }










    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded) State = CharState.Idle;
        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButton("Horizontal") && !damaged) Run();
        //if (Input.GetButtonDown("Vertical")) squat = true;
        //else squat = false;

        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
      
        if (Input.GetButton("Fire3")) speed = 6.0F;
            else speed = 3.0F;
        Debug.Log("Velocity " +rigidbody.velocity);
    }

    private void Squat()
    {
        
    }

    private void FixedUpdate()
    {
        CheckGround();
    }


}

public enum CharState
{
    Idle,
    Run,
    Jump
}