using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownPlayerMovement : MonoBehaviour {

    

   
    public Animator anim;

    [SerializeField]
    private float speed;

    private bool idle;

    void Start () {


       
        anim = gameObject.GetComponent<Animator>();
    }

    

    void Update () {
        
        anim.SetBool("Idle", idle);


        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow)) //north
        {
            transform.Translate(Vector2.up * speed*Time.deltaTime);
            anim.Play("northWalk");
            idle = false;
        }
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow)) //south
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            anim.Play("southWalk");
            idle = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow)) //east
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.Play("eastWalk");
            idle = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow)) //west
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            anim.Play("westWalk");
            idle = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow)) //northeast
        {
            transform.Translate(Vector2.up * speed/1.41f * Time.deltaTime);
            transform.Translate(Vector2.right * speed/1.41f * Time.deltaTime);
            anim.Play("northeastWalk");
            idle = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow)) //northwest
        {
            transform.Translate(Vector2.up * speed / 1.41f * Time.deltaTime);
            transform.Translate(Vector2.left * speed / 1.41f * Time.deltaTime);
            anim.Play("northwestWalk");
            idle = false;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow)) //southeast
        {
            transform.Translate(Vector2.down * speed / 1.41f * Time.deltaTime);
            transform.Translate(Vector2.right * speed / 1.41f * Time.deltaTime);
            anim.Play("southeastWalk");
            idle = false;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow)) //southwest
        {
            transform.Translate(Vector2.down * speed / 1.41f * Time.deltaTime);
            transform.Translate(Vector2.left * speed / 1.41f * Time.deltaTime);
            anim.Play("southwestWalk");
            idle = false;
        }
        if ((!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow)) ||
            (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)))
        {
            idle = true;
        }




    }

    

}
