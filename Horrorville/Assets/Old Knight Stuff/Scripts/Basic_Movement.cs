using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Movement : MonoBehaviour {

    public float maxSpeed = 4;
    public float speed = 50f;
    public float jumpPower = 150f;

    private Rigidbody2D rb2d;
    public Animator anim;

    // if
    public bool grounded;
    public bool right;
    private bool player;
    public bool left;
    
    //stats
    public int curHealth;
    public int maxHealth = 5;

	void Start () {

        rb2d = gameObject.GetComponent<Rigidbody2D> ();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
   
	}
	

	void Update () {

        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Right", right);
        anim.SetBool("Left", left);
        anim.SetInteger("Health", curHealth);
        

        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            right = true;
            
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if(curHealth <= 0)
        {
            Die();
        }


       
       
	}

    void FixedUpdate()
    {
         Vector3 easeVelocity = rb2d.velocity;
         easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
         easeVelocity.x *= .75f;


        float h = Input.GetAxisRaw("Horizontal");

        {

             rb2d.velocity = easeVelocity;

        }

        rb2d.AddForce((Vector2.right * speed) * h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)

        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

    }
    void Die()
    {
        //restart
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage (int dmg)
    {
        curHealth -= dmg;
    }
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(knockbackDir.x * -200, knockbackDir.y * knockbackPwr, transform.position.z));


        }

        yield return 0;
    }
}

