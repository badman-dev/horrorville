using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {
    
    public float speed;
    Transform currentPatrolPoint;
   
    public Transform target;
    public float chaseRange;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if(distanceToTarget < chaseRange)
        {
            
            transform.Translate (Vector3.left * Time.deltaTime * speed);
        }



	}
}
