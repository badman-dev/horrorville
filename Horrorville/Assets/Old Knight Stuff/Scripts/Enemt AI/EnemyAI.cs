using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    public Transform target;
    public float chaseRange;

    public float awarenessRange;
    public float distanceToTarget;

    public bool right;
    public bool left;
    private Rigidbody2D rb2d;
    public bool disable;
  
    public Animator anim;

    public int curHealth;
    public int maxHealth = 2;


    
    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];

        curHealth = maxHealth;

        disable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetBool("Right", right);
        anim.SetBool("Left", left);

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= .75f;

        
        if (disable)
        {
            return;
        }
        if (!disable)
        {

            //Check distance to player
            distanceToTarget = Vector3.Distance(transform.position, target.position);

            //check if enemy aware of player - if not patrol
            if (distanceToTarget > awarenessRange)
            {
                Patrol();
            }

            //if player in range - chase
            if (distanceToTarget < awarenessRange)
            {
                Chase();
            }
        }

        if (curHealth <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("damageTrigger"));
            gameObject.GetComponent<Animator>().Play("enemy_death");
            disable = true;
            StartCoroutine(dieTime());
            SendMessageUpwards("Disabled", disable);
        }
        

    }
    private IEnumerator dieTime()
    {
        yield return new WaitForSeconds(0.24f);
        Destroy(gameObject);
    }
    void Patrol()
    {
        

        
            if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 1f)
            {
                if (currentPatrolIndex + 1 < patrolPoints.Length)
                {
                    currentPatrolIndex++;
                }
                else
                {
                    currentPatrolIndex = 0;
                }
                currentPatrolPoint = patrolPoints[currentPatrolIndex];
            }
            Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
            Vector3 newScale;
            if (patrolPointDir.x < 0f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                newScale = new Vector3(1, 1, 1);
                //  transform.localScale = newScale;
                left = true;
                right = false;
            }

            if (patrolPointDir.x > 0f)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                newScale = new Vector3(-1, 1, 1);
                right = true;
                left = false;
                //   transform.localScale = newScale;
            }
        
    }
    void Chase()
    {
        
            Vector3 targetdir = target.position - transform.position;
            
            if (targetdir.x < 0f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                
                left = true;
                right = false;
            }

            if (targetdir.x > 0f)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                
                
                right = true;
                left = true;
            }
        
    }
    public void Hurt(int hurt)
    {
        curHealth -= hurt;
        
    }
}
