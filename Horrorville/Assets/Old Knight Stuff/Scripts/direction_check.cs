using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction_check : MonoBehaviour {

    private Basic_Movement player;
    public Basic_Movement right;
    
    public bool grounded;
   
    // Use this for initialization
    void Start () {
        player = gameObject.GetComponentInParent<Basic_Movement>();
        
        
    }
	
	// Update is called once per frame
	void Update () {


         if (Input.GetAxis("Horizontal") < -0.1f)
         {
        player.left = true;
        player.right = false;
         }

        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            player.right = true;
            player.left = false;
        }  else
        {
            player.right = false;
            player.left = false;
        }
    }
}
