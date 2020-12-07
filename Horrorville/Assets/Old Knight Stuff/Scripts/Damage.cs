using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    private Basic_Movement player;

    bool disabled;

    bool happening;

   private  float damageCd = .3f;
    private float damageTimer = 0;
    void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<Basic_Movement>();
        disabled = gameObject.GetComponentInParent<EnemyAI>().disable;

    }
	
	void Update()
    {
        if (happening)
        {
            damageTimer = damageCd;
        }
    }
	void OnTriggerEnter2D(Collider2D col)
    {
        if (disabled)
        {
            return;
        }
        if (!disabled)
        {
            if (damageTimer > 0)
            {
                damageTimer -= Time.deltaTime;
            } else
            {


                if (col.CompareTag("Player"))
                {
                    player.curHealth = player.curHealth - 1;
                    happening = true;
                    StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
                }
            }
        }
    }
}
