using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFightControl : MonoBehaviour {
    public Animator anim;

    private float coolDownTimer = 0;

    private float coolDown = 0.7f;

    private float attackTimerRight = 0;
    private float attackTimerLeft = 0;
    private float gutCoolDownShort = 0.4f;
    private float gutCoolDownLong = 0.5f;
    private float upCoolDownShort = 0.45f;
    private float upCoolDownLong = 0.55f;
    private int lastAttack;

    public bool upAttackRight;
    public bool upAttackLeft;
    public bool gutAttack;

    public int playerCurrentHealth;
    private int maxHealth = 10;

    private float coolDownDamageTimer = 0;

    private bool isDodging;


    void Start () {
		anim = gameObject.GetComponent<Animator>();

        upAttackRight = false;
        upAttackLeft = false;
        gutAttack = false;

        isDodging = false;

        playerCurrentHealth = maxHealth;
	}

	
	void Update () {
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (attackTimerLeft < 0)
        {
            attackTimerLeft = 0;
        }
        if (attackTimerLeft > 0)
        {
            attackTimerLeft -= Time.deltaTime;
        }
        if (attackTimerRight < 0)
        {
            attackTimerRight = 0;
        }
        if (attackTimerRight > 0)
        {
            attackTimerRight -= Time.deltaTime;
        }
        if (coolDownDamageTimer < 0)
        {
            coolDownDamageTimer = 0;
        }
        if (coolDownDamageTimer > 0)
        {
            coolDownDamageTimer -= Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.LeftArrow) && !(Input.GetKey(KeyCode.RightArrow)) && coolDownTimer == 0)
        {
            
            StartCoroutine(DodgeLeft());

        }
        if (Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftArrow)) && coolDownTimer == 0)
        {

            StartCoroutine(DodgeRight());
        }

        if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.UpArrow) && attackTimerLeft == 0)
        {
            StartCoroutine(GutLeft());
        }
        if (Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.UpArrow) && attackTimerRight == 0)
        {
            StartCoroutine(GutRight());
        }
        if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.UpArrow) && attackTimerLeft == 0)
        {
            StartCoroutine(UpLeft());
        }
        if (Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.UpArrow) && attackTimerRight == 0)
        {
            StartCoroutine(UpRight());
        }

        if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyFightControl>().strongAttack && !isDodging && coolDownDamageTimer == 0)
        {
            StartCoroutine(StrongDamage());
        }
        if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyFightControl>().weakAttack && !isDodging && coolDownDamageTimer == 0)
        {
            StartCoroutine(WeakDamage());
        }
    }
    
    

    IEnumerator DodgeLeft()
    {
        isDodging = true;
        coolDownTimer = coolDown;
        anim.Play("dodgeLeft");
        yield return new WaitForSeconds(0.75f);
        anim.Play("centerIdle");
        isDodging = false;
    }
    IEnumerator DodgeRight()
    {
        isDodging = true;
        coolDownTimer = coolDown;
        anim.Play("dodgeRight");
        yield return new WaitForSeconds(0.75f);
        anim.Play("centerIdle");
        isDodging = false;
    }

    IEnumerator GutLeft()
    {
        coolDownTimer = gutCoolDownLong;
        gutAttack = true;
        attackTimerLeft = gutCoolDownLong;
        attackTimerRight = gutCoolDownShort;
        anim.Play("punchGutLeft");
        yield return new WaitForSeconds(0.25f);
        anim.Play("centerIdle");
        gutAttack = false;
    }
    IEnumerator GutRight()
    {
        coolDownTimer = gutCoolDownLong;
        gutAttack = true;
        attackTimerLeft = gutCoolDownShort;
        attackTimerRight = gutCoolDownLong;
        anim.Play("punchGutRight");
        yield return new WaitForSeconds(0.25f);
        anim.Play("centerIdle");
        gutAttack = false;
    }
    IEnumerator UpLeft()
    {
        coolDownTimer = upCoolDownLong;
        upAttackLeft = true;
        attackTimerLeft = upCoolDownLong;
        attackTimerRight = upCoolDownShort;
        anim.Play("punchUpLeft");
        yield return new WaitForSeconds(0.3f);
        anim.Play("centerIdle");
        upAttackLeft = false;
    }
    IEnumerator UpRight()
    {
        upAttackRight = true;
        coolDownTimer = upCoolDownLong;
        attackTimerLeft = upCoolDownShort;
        attackTimerRight = upCoolDownLong;
        anim.Play("punchUpRight");
        yield return new WaitForSeconds(0.3f);
        anim.Play("centerIdle");
        upAttackRight = false;
    }

    IEnumerator WeakDamage()
    {
        playerCurrentHealth -= 1;
        attackTimerLeft = .55f;
        attackTimerRight = .55f;
        coolDownDamageTimer = .55f;
        coolDownTimer = .55f;
        anim.Play("hurt");
        yield return new WaitForSeconds(.5f);
        anim.Play("centerIdle");
    }
    IEnumerator StrongDamage()
    {
        playerCurrentHealth -= 1;
        attackTimerLeft = .75f;
        attackTimerRight = .75f;
        coolDownDamageTimer = .75f;
        coolDownTimer = .75f;
        anim.Play("hurt");
        yield return new WaitForSeconds(.7f);
        anim.Play("centerIdle");
    }
}
