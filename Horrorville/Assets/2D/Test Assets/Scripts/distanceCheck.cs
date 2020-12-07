using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceCheck : MonoBehaviour {
    public float dist;
    
    public GameObject enemyPoint;

    public Animator anim;
    
    void Start () {
        enemyPoint = GameObject.FindGameObjectWithTag("pointReference");

        anim = gameObject.GetComponent<Animator>();
    }
	
	
	void Update () {
       dist = transform.position.x - enemyPoint.transform.position.x;
        
        if (transform.position.x > enemyPoint.transform.position.x)
        {
            if (dist >= 7.5)
            {
                anim.Play("battleIdleK");
            }
            if (dist >= 6 && dist < 7.5)
            {
                anim.Play("battleIdleJ");
            }
            if (dist >= 4.5 && dist < 6)
            {
                anim.Play("battleIdleI");
            }
            if (dist >= 3 && dist < 4.5)
            {
                anim.Play("battleIdleH");
            }
            if (dist >= 1.5 && dist < 3)
            {
                anim.Play("battleIdleG");
            }
            if (dist < 1.5)
            {
                anim.Play("battleIdleF");
            }
            
                
        }
        if (transform.position.x == enemyPoint.transform.position.x)
        {
            anim.Play("battleIdleF");
        }
        if (transform.position.x < enemyPoint.transform.position.x)
        {
            if (-dist >= 7.5)
            {
                anim.Play("battleIdleA");
            }
            if (-dist >= 6 && -dist < 7.5)
            {
                anim.Play("battleIdleB");
            }
            if (-dist >= 4.5 && -dist < 6)
            {
                anim.Play("battleIdleC");
            }
            if (-dist >= 3 && -dist < 4.5)
            {
                anim.Play("battleIdleD");
            }
            if (-dist >= 1.5 && -dist < 3)
            {
                anim.Play("battleIdleE");
            }

            if (-dist < 1.5)
            {
                anim.Play("battleIdleF");
            }
        }
        }
    }

