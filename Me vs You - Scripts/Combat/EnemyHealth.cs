using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float health = 100f;

    [SerializeField] CanvasGroup healhtBar;
    [SerializeField] Slider onGoingHP;
    [SerializeField] TMPro.TextMeshProUGUI maxHP;
    [SerializeField] TMPro.TextMeshProUGUI currentHP;

    Animator anim;
    Player player;
    Rigidbody rigid;
    Collider colliders;
    CombatTarget target;
    EnemyHealth healths;
    Entity enemy;
    SkillSystem skill;

    public float maxHealth;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        player = FindObjectOfType<Player>();
        rigid = GetComponent<Rigidbody>();
        colliders = GetComponent<Collider>();
        target = GetComponent<CombatTarget>();
        healths = GetComponent<EnemyHealth>();
        enemy = GetComponent<Entity>();

        maxHealth = health;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8 && health > 0)
        {
            healhtBar.alpha = Mathf.Lerp(healhtBar.alpha, 1, Time.deltaTime * 5f);
        }
        else
        {
            healhtBar.alpha = Mathf.Lerp(healhtBar.alpha, 0, Time.deltaTime * 5f);
        }

        if (health <= 0) healhtBar.alpha = 0;

        healhtBar.transform.LookAt(Camera.main.transform);

        onGoingHP.value = health;
        maxHP.text = maxHealth.ToString("0");
        currentHP.text = health.ToString("0") + " / ";
    }

    public void Damage(float amount)
    {
        if (health <= 0) return;
        enemy.gotHit = true;

        rigid.AddForce(Vector3.up * 10f);

        health = Mathf.Max(health - amount, 0);

        if(health <= 0)
        {
            colliders.enabled = false;
            target.enabled = false;
            //healths.enabled = false;
            player.currentTarget = null;
            
        }
    }
}
