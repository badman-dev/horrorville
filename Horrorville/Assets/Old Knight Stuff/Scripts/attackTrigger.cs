using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

    public int dmg = 1;
    bool right;
    bool left;
    private float hurtCd;
    private float hurtTimer;
    private BoxCollider2D bx2d;
    

    
    void Start()
    {
        
    }

    
    void Update()
    {

        

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Hurt", dmg);
        }
    }
	
}
