using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Animator animator;
    public bool died = false;
    public GameManagerScript game;

    [SerializeField] EnemyHealthBar healthBar;
    gameAudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<gameAudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void takeDamage(int damage)
    {
        if (!died)
        {
            audioManager.PlaySFX(audioManager.enemy_grunt);
            currentHealth -= damage;
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
            animator.SetTrigger("hurt");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        died = true;
        Debug.Log("Enemy died.");
        audioManager.PlaySFX(audioManager.enemy_death);
        animator.SetBool("isDead", true);
        Destroy(gameObject, 1f);

        
    }
}
