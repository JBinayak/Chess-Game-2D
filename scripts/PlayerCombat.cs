using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public GameManagerScript gameManager;
    public Animator animator;
    public bool died = false;
    public ParticleSystem healEffect;
    public int maxHealth = 100;
    private int currentHealth;
    public float attackRate = 2;
    public float healRate = 10;
    float nextAttackTime = 0;
    float nextHealTime = 0;
    [SerializeField] PlayerHealthBar healthBar;
    gameAudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<gameAudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<PlayerHealthBar>();
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("attacking");
                Attack();
                nextAttackTime = Time.time + 1 / attackRate;
            }
        }

        if (Time.time >= nextHealTime)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                healEffect.Play();
                Heal();
                nextHealTime = Time.time + 1 / healRate;
            }
        }

    }

    void Attack()
    {
        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // Deal damage to enemies
        audioManager.PlaySFX(audioManager.player_attack);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<enemy>().takeDamage(20);
        }
    }

    void Heal()
    {
        audioManager.PlaySFX(audioManager.player_heal);
        currentHealth += 40;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        // visualizing the attack
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void takeDamage(int damage)
    {
        if (!died)
        {
            audioManager.PlaySFX(audioManager.player_grunt);
            currentHealth -= damage;
            animator.SetTrigger("gotHit");
            healthBar.UpdateHealthBar(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                died = true;
                animator.SetBool("hasDied", true);
                Invoke("Die", 1);
            }
        }
    }

    void Die()
    {
        audioManager.PlaySFX(audioManager.player_death);
        Debug.Log("Player died.");
        gameObject.SetActive(false);
        gameManager.gameOver();
    }
}