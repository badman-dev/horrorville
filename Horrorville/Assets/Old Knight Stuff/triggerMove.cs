using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMove : MonoBehaviour
{

    bool right;
    bool left;

    private BoxCollider2D bx2d;

    void Start()
    {
        right = gameObject.GetComponentInParent<Basic_Movement>().right;
        left = gameObject.GetComponentInParent<Basic_Movement>().left;
        
    }

    void SetTransformX(float n)
    {
        transform.localPosition = new Vector3(n, transform.position.y, transform.position.z);
    }
    void Update()
    {

        if (right)
        {
            SetTransformX(0.9f);
            //  transform.position = new Vector3(.9f, -.27f, 0);
        }


        if (left)
        {
            SetTransformX(-.9f);
            // bx2d.transform.position = new Vector3(-.9f, -.27f, 0);
        }
    }
}
