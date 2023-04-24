using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour, IDamageable
{
    [SerializeField] UnityEvent startingGame;

    public float health = 6000f;
    public bool hittable = true;

    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI maxHP;
    [SerializeField] TMPro.TextMeshProUGUI currentHP;
    public Transform lockOnTarget;

    Animator anim;
    Player player;
    Rigidbody rigid;
    Collider colliders;
    CombatTarget target;
    EnemyHealth healths;

    public float maxHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        rigid = GetComponent<Rigidbody>();
        colliders = GetComponent<Collider>();
        target = GetComponent<CombatTarget>();
        healths = GetComponent<EnemyHealth>();

        maxHealth = health;
    }

    private void Start()
    {

        slider.maxValue = maxHealth;
        maxHP.text = maxHealth.ToString("0");
    }

    private void OnEnable()
    {
        startingGame.Invoke();
    }

    private void Update()
    {
        slider.value = health;
        currentHP.text = health.ToString("0") + " / ";
    }

    void CanGetDamage()
    {
        hittable = true;
    }

    void CanNotGetDamage()
    {
        hittable = false;
    }
    public void Damage(float amount)
    {
        if (health <= 0) return;

        //rigid.AddForce(Vector3.up * 10f);

        if(hittable)
            health = Mathf.Max(health - amount, 0);

        if (health <= 0)
        {
            //colliders.enabled = false;
            //target.enabled = false;
            //healths.enabled = false;
            player.currentTarget = null;

        }
    }
}
