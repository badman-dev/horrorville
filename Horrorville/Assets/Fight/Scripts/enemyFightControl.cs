using System.Collections;
using UnityEngine;

public class enemyFightControl : MonoBehaviour
{

    public Animator anim;
    int result;
    int damageResult;

    private float coolDownTimer = 0;
    private float coolDownWeak = 1.3f;
    private float coolDownStrong = 1.55f;
    private float coolDownShort = .35f;
    private float coolDownBlock;

    public int currentHealth;
    private int maxHealth = 52;

    private float coolDownDamageTimer = 0;
    private float coolDownDamage = .3f;

    public bool isBlocking;

    public bool strongAttack;
    public bool weakAttack;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        coolDownTimer = 2;
        coolDownDamageTimer = 2;

        currentHealth = maxHealth;

        strongAttack = false;
        weakAttack = false;

        isBlocking = false;
    }


    void Update()
    {
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (coolDownTimer == 0 || result == 14)
        {
            int result = Random.Range(1, 12);
            if (result == 1 || result == 2)
            {
                coolDownTimer = coolDownShort;
            }
            if (result >= 3 && result <= 6)
            {
                StartCoroutine(WeakAttack());
            }
            if (result == 7 || result == 8)
            {
                StartCoroutine(StrongAttack());
            }
            if (result == 9 || result == 10)
            {
                coolDownTimer = Random.Range(.05f, 4);
            }
            if (result == 11)
            {
                StartCoroutine(Block());
            }
            if (result >= 12 && result <= 13)
            {
                coolDownTimer = .35f;
            }

        }
        if (coolDownDamageTimer < 0)
        {
            coolDownDamageTimer = 0;
        }
        if (coolDownDamageTimer > 0)
        {
            coolDownDamageTimer -= Time.deltaTime;
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerFightControl>().upAttackRight && !isBlocking && coolDownDamageTimer == 0)
        {
            coolDownDamageTimer = coolDownDamage;
            currentHealth -= 1;
            if (coolDownTimer > 0 && coolDownTimer <= .5)
            {
                StartCoroutine(DamageRight());
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerFightControl>().upAttackLeft && !isBlocking && coolDownDamageTimer == 0)
        {
            coolDownDamageTimer = coolDownDamage;
            currentHealth -= 1;
            if (coolDownTimer > 0 && coolDownTimer <= .5)
            {
                StartCoroutine(DamageLeft());
            }
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerFightControl>().gutAttack && !isBlocking && coolDownDamageTimer == 0)
        {
            coolDownDamageTimer = coolDownDamage;
            currentHealth -= 1;
            if ((coolDownTimer > 0 && coolDownTimer <= .5) || result == 9 || result == 10)
            {
                StartCoroutine(DamageGut());
            }
        }

    }
    IEnumerator WeakAttack()
    {
        coolDownTimer = coolDownWeak;
        anim.Play("testenemyWeakPrepare");
        yield return new WaitForSeconds(0.3f);
        anim.Play("testenemyWeakAttack");
        weakAttack = true;
        yield return new WaitForSeconds(0.5f);
        anim.Play("testenemyIdle");
        weakAttack = false;
    }
    IEnumerator StrongAttack()
    {
        coolDownTimer = coolDownStrong;
        anim.Play("testenemyStrongPrepare");
        yield return new WaitForSeconds(0.35f);
        anim.Play("testenemyStrongAttack");
        strongAttack = true;
        yield return new WaitForSeconds(.6f);
        anim.Play("testenemyIdle");
        strongAttack = false;
    }
    IEnumerator Block()
    {
        isBlocking = true;
        coolDownBlock = Random.Range(1, 7);
        coolDownTimer = coolDownBlock + .5f;
        anim.Play("testenemyBlock");
        yield return new WaitForSeconds(coolDownBlock);
        anim.Play("testenemyIdle");
        isBlocking = false;
    }


    IEnumerator DamageRight()
    {
        anim.Play("testenemyDamagedRight");
        yield return new WaitForSeconds(0.3f);
        anim.Play("testenemyIdle");
        int result = Random.Range(12, 15);
    }
    IEnumerator DamageLeft()
    {
        anim.Play("testenemyDamagedLeft");
        yield return new WaitForSeconds(0.3f);
        anim.Play("testenemyIdle");
        int result = Random.Range(12, 15);
    }
    IEnumerator DamageGut()
    {
        anim.Play("testenemyDamagedGut");
        yield return new WaitForSeconds(0.25f);
        anim.Play("testenemyIdle");
        int result = Random.Range(12, 15);
    }
}
