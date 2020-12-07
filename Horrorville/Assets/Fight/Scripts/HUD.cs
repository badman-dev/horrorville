using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour {

    public Sprite[] EnemyHealth;
    public Sprite[] PlayerHealth;

    public Image HeartUI;
    public Image PlayerHeartUI;
    private GameObject Enemy;
    private enemyFightControl enemy;

    private GameObject Player;
    private playerFightControl player;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").GetComponent<playerFightControl>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<enemyFightControl>();
    }
    void Update ()
    {
        if (enemy.currentHealth < 0)
        {
            enemy.currentHealth = 0;
        }
        if (player.playerCurrentHealth < 0)
        {
            player.playerCurrentHealth = 0;
        }
        HeartUI.sprite = EnemyHealth[enemy.currentHealth];
        PlayerHeartUI.sprite = PlayerHealth[player.playerCurrentHealth];
    }
}
