using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Basic_Movement player;
   
    void Start()
    {

        player = gameObject.GetComponentInParent<Basic_Movement>();
    
    }

    void  OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }
     void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }





    void OnTriggerExit2D(Collider2D col)
    {

        player.grounded = false;

    }


}
